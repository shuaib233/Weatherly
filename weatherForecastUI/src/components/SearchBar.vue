<template>
            <!-- Search Bar Section -->
      
    <section class="header-main border-bottom bg-white shadow mb-2 bg-grad rounded">

            <div class="">
                <div class="row p-2 pt-3 pb-3 d-flex align-items-center">
                    <div class="col-8 col-lg-8 col-md-8 col-sm-8 col-xs-8">

                            <div class="d-flex form-inputs">
                            <input class="form-control txt-search" type="text" v-model="searchTerm" @input="handleInput" placeholder="Search by city or zipcode...">
                            <i class="bx bx-search"></i>
                            </div>

                    </div>
                    
                    <div class="col-2 col-lg-2 col-md-2 col-sm-2 col-xs-2">
                    <button  @click="searchTermChanged" type="button" class="btn btn-dark btn-search">Search</button>
                    </div>
                
                </div>
            </div> 

            <ul v-if="searchCities.length && !isSelected" class="col-8 search-list">
                    <li
                    v-for="city in searchCities"
                    :key="city.name"
                    @click="selectionChanged(city.name)">
                    {{ city.name }}
                    </li>
            </ul>

    </section>


</template>
  
  <script>
  import { inject , ref, computed } from 'vue'
  import cities from '../data/cities.json'

  export default {
    setup() {
    const searchTerm = ref('')
    const isSelected = ref(true)

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
        searchTerm,
        isSelected,
        searchCities
      };
    },
    mounted() {
   this.searchTerm = this.defaultCity;
},
methods: {
    searchTermChanged () {
        this.isSelected = true;
        this.$emit('searchChanged',this.searchTerm)
    },
    selectionChanged(city){
        this.isSelected = true;
        this.searchTerm = city
        this.$emit('selectionChanged',city)
    },
    handleInput(){
        this.isSelected = false
    }
},
  };
  </script>
  
<style scoped>

/* Search Bar Styles */

.search-list
{
  z-index: 10000;
  overflow: hidden;cursor: pointer;
  position: absolute;
  list-style: none;
     
}

.search-list > li {
  color: peachpuff;
  background: rgba(0,0,0, 0.8);
  height: 40px;
  line-height: 40px;
  cursor: pointer;
  font-size: 17px;
}

.search-list li:hover {
  background: black;
}

body{
  background: #fff;
}

.form-inputs{
    position:relative;
}
.form-inputs .form-control{
    height:45px; 
}

.form-inputs .form-control:focus{
    box-shadow:none;
    border:1px solid #000;
}

.form-inputs i{
    position:absolute;
    right:10px;
    top:15px;
}

.txt-search{
	border-radius: 0px;
  text-align: center;
}

.btn-search{
	border-radius: 0px;
	min-width: 90%;
	padding: 9px;
}

</style>