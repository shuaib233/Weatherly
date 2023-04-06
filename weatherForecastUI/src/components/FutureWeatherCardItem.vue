<script setup>
/* Render the Future Weather Card Item */
const {futureWeather} = defineProps(['futureWeather'])
</script>

<template>

<div>

  <h3 class="day">{{futureWeather.day}}</h3>
      <img  v-bind:src="`${futureWeather.weatherIcon}`" class="img-sm" alt="weather icon">

			<p class="conditions">{{ futureWeather.weather }}
			</p>

			<p class="tempRange">
       			 {{ futureWeather.temperatureC | filters.formatNumber}}<span class="temperature"></span>
      			 C | {{futureWeather.temperatureF | filters.formatNumber}}<span class="temperature"></span> F
			</p>

		<div class="row">
		 <div class="col-lg-12  col-md-12 col-sm-6 col-xs-6">
			<img src="../assets/images/hot.png" class="card-f-icon" alt="temperature icon"> 
			<span class="weather-f-desc"> {{futureWeather.feelsLike | filters.formatNumber}}<span class="temperature"></span> C</span>
		</div>

		<div class="col-lg-12  col-md-12 col-sm-6 col-xs-6">
			<img src="../assets/images/wind.png" class="card-f-icon"  alt="wind icon"> 
			<span class="weather-f-desc"> {{futureWeather.wind | filters.formatNumber}} m/h </span>
		</div>
	</div>
	
	<div class="row">
		 <div class="col-lg-12  col-md-12 col-sm-12 col-xs-12">
			<img src="../assets/images/humid.png" class="card-f-icon" alt="humidity icon"> 
			<span class="weather-f-desc">{{futureWeather.humidity | filters.formatNumber}}%</span>
		</div>
	</div>


</div>
</template>

<style scoped>

#future .card{
	box-shadow: 0px 0px 25px 1px rgba(50, 50, 50, 0.1);
	padding:10px;
}

.weather-f-desc
{
	font-family: math;
	font-size: 12px;
}

.card-f-icon{
	height: 15px;
	width:15px;
	margin-right: 5px;
}

.card-icon{
	height: 25px;
	width:25px;
}

.temp-f {
	font-size: 20px;
}


.weather-f-desc ::after {
    content: "\00b0"
}

.tempRange{
	margin-bottom: 0px;
	font-size: 14px;
}

.day{
	padding-top: 5px;
}

</style>
