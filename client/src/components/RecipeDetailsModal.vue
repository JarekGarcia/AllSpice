<template>
    <div @blur="clearActiveRecipe()" class="modal" id="recipeDetailsModal" tabindex="-1" role="dialog">
        <div v-if="recipe" class="modal-dialog modal-xl" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title">{{ recipe.title }}</h5>
                    <button type="button" class="close btn btn" data-bs-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="container-fluid">
                    <section class="row">
                        <div class="col-12 col-md-4 p-2">
                            <img class="img-fluid w-100 rounded" :src="recipe.img" :alt="recipe.title">
                        </div>
                        <div class="col-12 col-md-4 p-2">
                            <p class="fw-bold">Ingredients:</p>
                            <div v-for="ingredient in activeIngredients" :key="ingredient.id">
                                {{ ingredient.name }}:
                                {{ ingredient.quantity }}
                            </div>
                        </div>
                        <div class="col-12 col-md-4 p-2">
                            <div>
                                <p class="fw-bold">Instructions:</p>
                            </div>
                            <div>
                                {{ recipe.instructions }}
                            </div>
                        </div>
                    </section>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Close</button>
                    </div>
                </div>
            </div>
        </div>
    </div>
</template>


<script>
import { AppState } from '../AppState';
import { computed, reactive, onMounted } from 'vue';
import Pop from '../utils/Pop';
import { recipesService } from '../services/RecipesService';
export default {
    setup() {


        return {
            recipe: computed(() => AppState.activeRecipe),
            activeIngredients: computed(() => AppState.activeIngredients),

            async clearActiveRecipe() {
                try {
                    const activeRecipe = await recipesService.clearActiveRecipe()
                    return activeRecipe
                } catch (error) {
                    Pop.error(error)
                }
            }
        }

    }
};
</script>


<style lang="scss" scoped>
img {
    background-size: cover;
    object-fit: cover;
    height: 25vh;
}
</style>