using Microsoft.AspNetCore.Mvc;
using weatherForcastWebAPI.Models;
using Newtonsoft.Json;

namespace weatherForcastWebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private readonly IConfiguration _configuration;
    private readonly string _apiURL;
    private readonly string _apiAppId;
    private readonly string _apiIconPath;

    public WeatherForecastController(IConfiguration configuration)
    {
        _configuration = configuration;
        _apiURL = _configuration.GetSection("WeatherAPI").GetSection("URL").Value;
        _apiAppId = _configuration.GetSection("WeatherAPI").GetSection("AppId").Value;
        _apiIconPath = _configuration.GetSection("WeatherAPI").GetSection("IconPath").Value;
    }

    /// <summary>
    /// Get Weather data from Open Weather API by City name or zip code
    /// </summary>
    /// <param name="parameter"></param>
    /// <returns>WeatherForcastAPIResponseModel</returns>
    [HttpGet("GetWeather/{parameter}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<IActionResult> GetWeather(string parameter)
    {

        using (var client = new HttpClient())
        {
            try
            {
                client.BaseAddress = new Uri(_apiURL);
                HttpResponseMessage response = await client.GetAsync($"/data/2.5/forecast?{GetQueryParameter(parameter)}={parameter}&appid={_apiAppId}&units=metric");
                response.EnsureSuccessStatusCode();

                var stringResult = await response.Content.ReadAsStringAsync();
                var coreData = JsonConvert.DeserializeObject<OpenWeatherListResponse>(stringResult);

                WeatherForcastAPIResponseModel vm = new WeatherForcastAPIResponseModel
                {
                    Data = coreData.List.GroupBy(x => x.Dt_txt.Date)
                                        .Select(GetAggregateData),
                    City = coreData.City.Name
                };
                return Ok(vm);
            }
            catch (HttpRequestException httpRequestException)
            {
                return  NotFound($"Bad Request, No data found: {httpRequestException.Message}");
            }
        }

    }

    /// <summary>
    /// Manipulate the data to render on front-end, like Calculates averages and form icon path
    /// </summary>
    /// <param name="group"></param>
    /// <returns>WeatherForcastAPIResponse</returns>
    private WeatherForcastAPIResponse GetAggregateData(IGrouping<DateTime,OpenWeatherResponse> group)
    {
        return new WeatherForcastAPIResponse
        {
            Date = group.Key.ToString("dddd, dd MMMM yyyy"),
            Day = group.Key.ToString("ddd"),
            Visibility =  group.FirstOrDefault()?.Visibility,
            Clouds = group.Average(y => y.Clouds.all),
            TemperatureC = group.Average(s => s.Main.Temp),
            Humidity = group.Average(s => s.Main.Humidity),
            FeelsLike = group.Average(s => s.Main.Feels_Like),
            Pressure = group.Average(y => y.Main.Pressure),
            Wind = group.Average(z => z.Wind.Speed),
            Weather =  group.FirstOrDefault()?.Weather.FirstOrDefault()?.Main,
            WeatherDescription = group.FirstOrDefault()?.Weather.FirstOrDefault()?.Description,
            WeatherIcon = String.Concat(_apiIconPath, "/img/wn/", group.FirstOrDefault()?.Weather.FirstOrDefault()?.Icon, "@2x.png"),
        };
    }

    /// <summary>
    /// Decides which API End point to hit, based on data type of search parameter
    /// zip; for zip code
    /// q; for city name
    /// </summary>
    /// <param name="parameter"></param>
    /// <returns>String</returns>
    private  string GetQueryParameter(string parameter)
    {
        bool isZipCode = int.TryParse(parameter, out _);
        string queryParameterType = isZipCode ? "zip" : "q";
        return queryParameterType;
    }

}
