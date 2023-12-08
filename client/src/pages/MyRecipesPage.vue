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
import { AppState } from '../AppState';
import { computed, reactive, onMounted } from 'vue';
import RecipesCard from '../components/RecipesCard.vue';
import Pop from '../utils/Pop';
import { recipesService } from '../services/RecipesService';
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
        }
    },
    components: { RecipesCard }
};
</script>


<style lang="scss" scoped></style>