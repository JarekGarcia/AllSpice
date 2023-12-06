<template>
  <div class="container-fluid">
    <section class="row">
      <div v-for="recipe in recipes" :key="recipe.id" class="col-12 col-md-4">
        <RecipesCard :recipesProp="recipe" />
      </div>
    </section>
  </div>
</template>

<script>
import Pop from '../utils/Pop';
import { recipesService } from '../services/RecipesService';
import { computed, onMounted } from 'vue';
import { AppState } from '../AppState';
import RecipesCard from '../components/RecipesCard.vue';

export default {
  setup() {

    onMounted(() => {
      getRecipes()
    })

    async function getRecipes() {
      try {
        await recipesService.GetRecipes()
      } catch (error) {
        Pop.error(error)
      }
    }

    return {
      recipes: computed(() => AppState.recipes)

    };
  },
  components: { RecipesCard }
}
</script>

<style scoped lang="scss">
.home {
  display: grid;
  height: 80vh;
  place-content: center;
  text-align: center;
  user-select: none;

  .home-card {
    width: clamp(500px, 50vw, 100%);

    >img {
      height: 200px;
      max-width: 200px;
      width: 100%;
      object-fit: contain;
      object-position: center;
    }
  }
}
</style>
