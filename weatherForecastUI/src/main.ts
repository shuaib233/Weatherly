import "bootstrap/dist/css/bootstrap.min.css"
import { createApp } from 'vue'
import App from './App.vue'
import router from './router'
import './assets/main.css'
import { Chart, LineController, ArcElement, Tooltip } from 'chart.js';
Chart.register(LineController, ArcElement, Tooltip);

const app = createApp(App)

app.use(router)

// FILTER REGISTERATION

app.config.globalProperties.filters = {
    formatNumber(value:any) {
      if (!value) return '0.0';
      return parseFloat(value).toFixed(1);
    }
  };
app.config.globalProperties.defaultCity = 'Berlin'

app.mount('#app')

import "bootstrap/dist/js/bootstrap.js"
