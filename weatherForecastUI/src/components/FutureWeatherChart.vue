<template>
    <!--Renders Weather Line Chart to display future 5 days forecast-->
    <canvas id="weather-chart" ref="chartRef"></canvas>
</template>
  
  <script>
  import { ref, onMounted, watch } from 'vue'
  import Chart from 'chart.js/auto'
  
  export default {
    props: {
      chartData: {
        type: Array,
        required: true,
      },
    },
    setup(props) {
      const chartRef = ref(null)
  
      // Create Line chart on mounted
      onMounted(() => {
        const ctx = chartRef.value.getContext('2d')
        const chart = new Chart(ctx, {
          type: 'line',
          data: {
            labels: props.chartData.map((data) => data.day),
            datasets: [
              {
                label: 'Temperature °C',
                data: props.chartData.map((data) => data.temperatureC),
                borderWidth:3,
                borderColor: 'yellow',
                color:'rgb(75, 192, 192)',
                fill: true,
                tension: 0.3,
                backgroundColor:'rgba(251, 255, 110, 0.3)',
                pointRadius:5,
                hoverBorderColor:'black',
                hoverBackgroundColor:'rgb(75, 192, 192)'
              },
            ],
          },
          options: {
                scales: {
                y: {
                    grid: {
                display: false
                },
                    beginAtZero: true
                },
                x:{
                    grid: {
                display: false
                }
                 }
                        }
                  }
        })
      })
  
      // Update chart when data changes
      watch(() => props.chartData, () => {
        const chart = Chart.getChart(chartRef.value)
        chart.data.labels = props.chartData.map((data) => data.day)
        chart.data.datasets[0].data = props.chartData.map((data) => data.temperatureC)
        chart.update()
      })
  
      return {
        chartRef,
      }
    },
  }
  </script>
  
  <style scoped>
  #weather-chart{
    max-height: 250px;
  }
</style>