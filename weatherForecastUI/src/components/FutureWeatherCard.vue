<script>
import FutureWeatherCardItem from './FutureWeatherCardItem.vue'
/*Future Weather Card to display list of futureCardItems*/
export default {
    props: {
        futureWeather: {
        type: Object,
        required: false,
      },
    },
    components:{
        FutureWeatherCardItem,
  },
    setup() {
     
    },
  }
</script>

<template>
<div>
    
<!-- Loop through the 5 days future weather data to create FutureWeatherCardItems-->
    <div class="row">
      <div v-for="(item) in futureWeather" :key="item.id" class="card-col col-sm-12 card m-1">
      <FutureWeatherCardItem :futureWeather="item"></FutureWeatherCardItem>
      </div>
    </div>  

</div>
</template>

<style scoped>
@media (min-width: 880px) {
.card-col{
	width: 18.8%;
}

}
</style>
