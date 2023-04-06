<script setup>
/* Render The Search History Items */
const {weather} = defineProps(['weather'])
</script>

<template>

<div>

    <span class="d-inline-flex align-items-center justify-content-center row">
		<div class="col-3">
					<img v-bind:src="`${weather.icon}`" class="img-sm" alt="weather icon">
		</div>
		<div class="col-9">
	  <p class="city">{{weather.city}}</p>
	  <p class="conditions-history">{{ weather.weather }}</p>
	  <p class="tempRange">
		<img src="../assets/images/hot.png" class="history-icon m-1" alt="temperature icon"> 
		<span>{{weather.tempC | filters.formatNumber}}<span class="temperature"></span> C</span> 
		   | 
		<img src="../assets/images/humid.png" class="history-icon m-1" alt="humidity icon"> 
		<span>{{weather.humidity | filters.formatNumber}}%</span>
	  </p>

	</div>
      </span>

</div>
</template>

<style scoped>
.history-icon
{
	height: 20px;
	width:20px;
}

.conditions-history {
    margin-bottom: 0rem;
	font-size: 15px;
}
.city
{
	font-size: 20px;
    margin-bottom: 0rem;
}
.list-group-item{
    padding: 0px;
}

.tempRange{
	margin-bottom: 0px;
	font-size: 15px;
}
</style>
