<script setup>

/* Renders today's weather of a searched city */

const {weatherModel,todayWeather} = defineProps(['weatherModel','todayWeather'])
</script>

<template>

<div class="r-5" :class="[todayWeather.clouds>80?'bg-cloudy':'bg-clear']">

		<!--Setup the backgroud cover of card-->
		<div class="shadow p-3 mb-5 rounded bg-img"> 

				<div class="row">
				
						<div class="col-lg-6 col-md-6 col-sm-12">

							<h3 class="location">{{weatherModel.city}}</h3>
							<h4 class="date">{{ todayWeather.date }}</h4>

							<img v-bind:src="`${todayWeather.weatherIcon}`" class="img-lg" alt="weather icon">
						
							<p class="temp">{{ todayWeather.temperatureC | filters.formatNumber}}<span class="temperature"></span> C 
						| {{ todayWeather.temperatureF | filters.formatNumber}}<span class="temperature"></span> F
							</p>

							<p class="conditions">{{ todayWeather.weather }} 
							</p>

							<p class="conditions">{{ todayWeather.weatherDescription }} 
							</p>

						</div>


						<div class="col-lg-6  col-md-6 col-sm-12 col-xs-12" >

						<div id="weather-info">

						<div class="row">

							<div class="col-lg-6  col-md-12 col-sm-12 col-xs-12">
								<img src="../assets/images/wind.png" class="card-icon" alt="wind icon"> 
								<span class="weather-desc">Wind: {{ todayWeather.wind | filters.formatNumber }} m/h</span>
							</div>

							<div class="col-lg-6  col-md-12 col-sm-12 col-xs-12">
								<img src="../assets/images/humid.png" class="card-icon" alt="humidity icon"> 
								<span class="weather-desc">Humidity: {{ todayWeather.humidity | filters.formatNumber}}%</span>
							</div>

						</div>
						
						<div class="row">

							<div class="col-lg-6  col-md-12 col-sm-12 col-xs-12">
								<img src="../assets/images/hot.png" class="card-icon" alt="feels like icon"> 
								<span class="weather-desc">Feels Like: {{ todayWeather.feelsLike | filters.formatNumber}} <span class="temperature"></span>  C</span>
							</div>

							<div class="col-lg-6  col-md-12 col-sm-12 col-xs-12">
								<img src="../assets/images/haze.png" class="card-icon" alt="visibility icon"> 
								<span class="weather-desc">Visibility: {{ todayWeather.visibility | filters.formatNumber}}</span>
							</div>

						</div>

						
						<div class="row">

							<div class="col-lg-6  col-md-12 col-sm-12 col-xs-12">
								<img src="../assets/images/cloud.png" class="card-icon" alt="clouds icon"> 
								<span class="weather-desc">Clouds: {{ todayWeather.clouds | filters.formatNumber}} %</span>
							</div>

							<div class="col-lg-6  col-md-12 col-sm-12 col-xs-12">
								<img src="../assets/images/pressure.png" class="card-icon" alt="pressure icon"> 
								<span class="weather-desc">Pressure: {{ todayWeather.pressure | filters.formatNumber}}</span>
							</div>

						</div>

					</div> 


						</div>

				</div>
			
		</div> <!--End of card div-->
</div> <!--End of background div-->

</template>

<style scoped>
.weather-desc
{
	font-family: system-ui;
    font-size: 15px;
}

.bg-img
{
	background: url('../assets/images/weather-bg.svg') no-repeat center;
    background-size: cover;
}

.r-5{
	border-radius: 5px;
}

/* Sets the blue background of today weather card when weather is clear */
.bg-cloudy{
	background: #e1ecff;
    background-image: linear-gradient(to left bottom, #767676, #b0b0b0, #c7c3c3, #ffffff, #ffffff);
}

/* Sets the grey background of today weather card if weather is cloudy*/
.bg-clear
{
	background: #e1ecff;
	background-image: linear-gradient(to left bottom, #d6eef6, #a4dbfc, #d4edff, #ffffff, #ffffff);
}

.temp {
	font-size: 1.2em;
    line-height: 0.5;
	margin-bottom: 10px;
}

.card-icon{
	height: 25px;
	width:25px;
	margin-right: 5px;
}

#current {
	padding: 10% 5% 20%;
	position: relative;
}
.location {
	font-size: 2em;
	font-weight: 500;
	margin: 0;
}
.date {
	font-size: 0.9em;
	font-weight: 300;
	text-transform: uppercase;
	margin-bottom: 0px;
}
.conditions {
	font-size: 1.2em;
	text-transform: uppercase;
	margin-bottom: 0px;
}

 .weatherIcon {
	height: 100px;
	margin: 10% auto 7%;
	width: 100px;
}

#weather-info{
	position: relative;
  bottom: 0;
  right: 0;
  left: 0;
}

/* Adjust the weather description */
@media (min-width: 880px) {
	#weather-info[data-v-f419e0b9] {
    position: absolute;
}

}

@media (min-width: 250px) {
	#weather-info[data-v-f419e0b9] {
	margin-top: 30px;
}

}

</style>
