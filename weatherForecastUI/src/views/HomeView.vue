
<!-- Render Search Bar and Child Components  -->

<template>

  <body class="app-container">

    <div id="current" >
        
      <!--Render Child Components-->

            <!-- Search Bar Component -->
               <SearchBar   @searchChanged="onSearchChanged" @selectionChanged="onSelectionChanged"></SearchBar>
              
    <div class="row">
      
      <div class="col-lg-8">

            <div v-if="isError" class="alert alert-danger"> No data found
            </div>
      
              <!--today weather card-->
              <n-spin :show="loading">
                <TodayWeatherCard :todayWeather="todayWeather" :weatherModel="weatherModel"></TodayWeatherCard>
              </n-spin>

              <!--future weather chart-->
              <n-spin :show="loading">
                <FutureWeatherChart v-if="futureWeather" :chart-data="chartData" /> 
              </n-spin>

              <!-- Future 5 day Forecast card -->
              <n-spin :show="loading" class="container">
                  <div id="future">
                    <FutureWeatherCard v-if="futureWeather" :futureWeather="futureWeather" /> 
                  </div>
              </n-spin>

      </div>
      
          <div class="col-lg-1">
          </div>
      
          <!-- Display user searched Items -->
          <div class="col-lg-3 history">
                <n-spin :show="loading">
                  <SearchHistoryCard v-if="weatherModel"  :todayWeather="todayWeather" :weatherModel="weatherModel" /> 
                </n-spin>
          </div>
      
      </div>
      
    </div>
  
  </body>

</template>

<script>
import { defineComponent, ref, computed } from 'vue'
import cities from '../data/cities.json'
import axios from 'axios'
import SearchBar from '../components/SearchBar.vue'
import TodayWeatherCard from '../components/TodayWeatherCard.vue'
import FutureWeatherCard from '../components/FutureWeatherCard.vue'
import FutureWeatherChart from '../components/FutureWeatherChart.vue'
import SearchHistoryCard from '../components/SearchHistoryCard.vue'
import { NSkeleton, NSpin } from 'naive-ui'
const API_URL = import.meta.env.VITE_APIURL;

export default defineComponent({
  name: 'WeatherApp',
  components: {
    TodayWeatherCard,
    FutureWeatherCard,
    FutureWeatherChart,
    NSkeleton,
    NSpin,
    SearchHistoryCard,
    SearchBar
  },
  setup() {
    const searchTerm = ref('')
    const selectedCity = ref('')
    const weatherModel = ref([])
    const todayWeather = ref({})
    const futureWeather = ref([])
    const chartData = ref([])
    const loading = ref(true)
    const isError = ref(false)

    // Fetch data from open weather API
    const getWeatherData = async () => {
        loading.value = true
        try {
              const response = await axios.get(API_URL+`${searchTerm.value}`)
              if (response.status === 200) {
                weatherModel.value = response.data
                todayWeather.value = response.data.data[0]
                futureWeather.value = response.data.data.slice(1)
                chartData.value = futureWeather.value
                loading.value = false
                isError.value = false
          }
        } catch (error) {
              if (error) {
                loading.value = false
                isError.value = true
              }
        }
    }

    // Sets selected to false, on user typing
    const handleInput = () => {
        isSelected.value = false
    }

    // Sets the selected city, on user's click on autocompleted results
    const selectCity = (city) => {
        selectedCity.value = city
        searchTerm.value = city
        getWeatherData()
    }

    // finds the matching results for user 
    const searchCities = computed(() => {
        if (searchTerm.value === '') {
          return []
        }

        let matches = 0

        return cities.filter(city => {
          if (city.name.toLowerCase().includes(searchTerm.value.toLowerCase()) && matches < 10) {
            matches++
            return city
          }
      })
    })

    return {
      cities,
      searchTerm,
      searchCities,
      selectCity,
      handleInput,
      selectedCity,
      weatherModel,
      todayWeather,
      futureWeather,
      getWeatherData,
      chartData,
      loading,
      isError
    }
  },

	mounted() {
      this.searchTerm = this.defaultCity;
      this.getWeatherData();
},
methods: {
      onSearchChanged(searchTerm){
        this.searchTerm = searchTerm
        this.getWeatherData()
      },
      onSelectionChanged(city){
        this.selectCity(city)
      }
},
})

</script>

<style scoped>

/** notification or alert styling */

.custom-notification{
  padding: 30px;
}

#future{
  margin-top: 20px;
}



</style>