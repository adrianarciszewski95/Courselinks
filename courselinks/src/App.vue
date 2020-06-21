<template>
  <div id="app">
    <div id="nav">
      <Navbar
      :user="user"
      :logged_in="logged_in"  />
    </div>
    <router-view 
    :logged_in="logged_in"
    :key="$route.fullPath" />
  </div>
</template>

<script>
  import Navbar from './components/Navbar.vue';
  import axios from 'axios';

  export default {
    name: 'app',
    components: {
      Navbar
      },
    data() {
      return {
        token: localStorage.getItem('user-token'),
        logged_in: false,
        user: null
        }
      },
    mounted() {
      if (this.token != null) {
        axios.get('https://localhost:5001/api/UserAuthorization', { headers: {"Authorization" : `Bearer ${this.token}`} })
        .then(response => this.user= response.data)
        .catch(error => console.log(error))
        this.logged_in = true
      }

    }
  }
</script>

<style lang="scss">
#app {
  text-align: center;
}
#nav {
  padding: 30px;
}
</style>

