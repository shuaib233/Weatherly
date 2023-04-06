<script>
import {ref,onMounted ,watch} from 'vue'
import SearchHistoryItem from './SearchHistoryCardItem.vue'

export default {
    props: {
        todayWeather: {
        type: Object,
        required: false,
      },
      weatherModel:{
        type: Object,
        required: false,
      },
    },
    components:{
  SearchHistoryItem,
  },
    setup(props) {
      const localStorageData = ref([])

      
  // Read search history from broswer local storage
      const getWeatherHistory = () =>{
            localStorageData.value = localStorage.getItem('weatherData')
            if(localStorageData.value==null)
            localStorageData.value = [];
            else
            localStorageData.value =  JSON.parse(localStorage.getItem('weatherData'))
}

// Setups the weather history on each search, and save in browser local storage

        const setWeatherHistory = () =>{

            localStorageData.value = localStorage.getItem('weatherData')

            let obj = {tempC:props.todayWeather.temperatureC,tempF:props.todayWeather.temperatureF,
            humidity:props.todayWeather.humidity,wind:props.todayWeather.wind,
            icon:props.todayWeather.weatherIcon,city:props.weatherModel.city,
            weather:props.todayWeather.weather}

            if(localStorageData.value==null)
            localStorageData.value = [];
            else
            localStorageData.value = JSON.parse(localStorage.getItem('weatherData'))
            localStorageData.value.unshift(obj);
            localStorage.setItem('weatherData', JSON.stringify(localStorageData.value));

}

      // Create chart on mounted
      onMounted(() => {
        getWeatherHistory();
      })
  
      // Update chart when data changes
      watch(() => props.todayWeather, () => {
        setWeatherHistory();
        getWeatherHistory();
      })
  
      return {
        getWeatherHistory,
        setWeatherHistory,
        localStorageData
      }
    },
  }
</script>

<template>
<div>

    <h6 class="bg-grad p-2 border-top border-bottom">Search History</h6>
    <ul class="list-group mx-auto">
    <!-- Forecast History Items -->
        <div v-for="(item) in localStorageData" :key="item.id" class="list-group-item">
          <SearchHistoryItem :weather=item></SearchHistoryItem>
        </div>
    </ul>

</div>
</template>

<style scoped>

</style>
