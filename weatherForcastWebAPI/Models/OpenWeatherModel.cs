using Newtonsoft.Json;

namespace weatherForcastWebAPI.Models
{
    public class OpenWeatherListResponse
    {
        public IEnumerable<OpenWeatherResponse> List { get; set; }
        public City City { get; set; }
    }

    public class OpenWeatherResponse
    {
        public string Name { get; set; }
        public string Visibility { get; set; }
        public IEnumerable<Weather> Weather { get; set; }
        public Main Main { get; set; }
        public Wind Wind { get; set; }
        public Clouds Clouds { get; set; }

        public DateTime Dt_txt { get; set; }
    }

    public class Weather
    {
        public string Main { get; set; }
        public string Description { get; set; }
        public string Icon { get; set; }
    }

    public class City
    {
        public string Name { get; set; }
    }

    public class Wind
    {
        public long Speed { get; set; }
    }

    public class Clouds
    {
        public long all { get; set; }
    }

    public class Main
    {
        public long Temp { get; set; }
        public long Feels_Like { get; set; }
        public long Humidity { get; set; }
        public string Temp_Min { get; set; }
        public string Temp_Max { get; set; }
        public long Pressure { get; set; }
    }


    /// <summary>
    /// Final response type that takes list of each day forcast that is returned to the front end
    /// JsonProperty keeps the json property consistent even if property name changes in class
    /// </summary>
    public class WeatherForcastAPIResponseModel
    {
        [JsonProperty("data")]
        public IEnumerable<WeatherForcastAPIResponse> Data { get; set; }
        [JsonProperty("city")]
        public string City { get; set; }
    }

    /// <summary>
    /// Response type that represents aggregated data of each day 
    /// JsonProperty keeps the json property consistent even if property name changes in class
    /// </summary>
    public class WeatherForcastAPIResponse
    {
        [JsonProperty("day")]
        public string Day { get; set; }

        [JsonProperty("date")]
        public string Date { get; set; }

        [JsonProperty("visibility")]
        public string? Visibility { get; set; }

        [JsonProperty("temperatureC")]
        public double TemperatureC { get; set; }

        [JsonProperty("temperatureF")]
        public double TemperatureF  => 32 + (int)(TemperatureC / 0.5556);

        [JsonProperty("feelsLike")]
        public double FeelsLike { get; set; }

        [JsonProperty("humidity")]
        public double Humidity { get; set; }

        [JsonProperty("pressure")]
        public double Pressure { get; set; }
        
        [JsonProperty("wind")]
        public double Wind { get; set; }

        [JsonProperty("weather")]
        public string? Weather { get; set; }

        [JsonProperty("weatherDescription")]
        public string? WeatherDescription { get; set; }

        [JsonProperty("weatherIcon")]
        public string? WeatherIcon { get; set; }

        [JsonProperty("clouds")]
        public double Clouds { get; set; }

    }

}
