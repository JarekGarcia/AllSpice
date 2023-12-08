<template>
  <div class="container-fluid bg-header">
    <section class="row">
      <nav class="navbar navbar-expand-sm navbar-dark px-3">
        <button class="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarText"
          aria-controls="navbarText" aria-expanded="false" aria-label="Toggle navigation">
          <span class="navbar-toggler-icon"></span>
        </button>
        <div class="collapse navbar-collapse" id="navbarText">
          <ul class="navbar-nav me-auto"></ul>
          <!-- LOGIN COMPONENT HERE -->
          <Login />
        </div>
      </nav>
    </section>
    <section class="row justify-content-center p-3">
      <div class="col-12 col-md-5 text-center text-white">
        <p class="fw-bold fs-1">All-Spice</p>
        <p class="fs-4">Cherish Your Family And Their Cooking</p>
      </div>
    </section>
    <section class="row p-3">
      <div class="d-flex text-center fw-bold align-items-center">
        <div class="col-12 col-md-2 rounded">
          <router-link :to="{ name: 'Home' }">
            <button class="btn btn text-white fw-bold bg-success">Home</button>
          </router-link>
        </div>
        <div class="col-12 col-md-2 mt-3">
          <router-link :to="{ name: 'MyRecipes' }">
            <button class="btn btn text-white fw-bold bg-success">My
              Recipes
            </button>
          </router-link>
        </div>
        <div class="col-12 col-md-2 mt-3"><button class="btn btn text-white fw-bold bg-success">Favorites</button>
        </div>
      </div>
    </section>
  </div>
</template>

<script>
import { onMounted, ref } from 'vue';
import { loadState, saveState } from '../utils/Store.js';
import Login from './Login.vue';
export default {
  setup() {

    const theme = ref(loadState('theme') || 'light')

    onMounted(() => {
      document.documentElement.setAttribute('data-bs-theme', theme.value)
    })

    return {
      theme,
      toggleTheme() {
        theme.value = theme.value == 'light' ? 'dark' : 'light'
        document.documentElement.setAttribute('data-bs-theme', theme.value)
        saveState('theme', theme.value)
      }
    }
  },
  components: { Login }
}
</script>

<style scoped>
a:hover {
  text-decoration: none;
}

.bg-header {
  background-image: url(https://images.unsplash.com/photo-1504674900247-0877df9cc836?q=80&w=2070&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D);
  background-size: cover;
  background-position: center;
}


.nav-link {
  text-transform: uppercase;
}

.navbar-nav .router-link-exact-active {
  border-bottom: 2px solid var(--bs-success);
  border-bottom-left-radius: 0;
  border-bottom-right-radius: 0;
}

@media screen and (min-width: 768px) {
  nav {
    height: 64px;
  }
}

.d-flex {
  display: flex;
  flex-direction: column;
}
</style>
