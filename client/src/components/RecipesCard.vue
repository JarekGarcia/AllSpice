<template>
    <div @click="getRecipeById(recipesProp.id), getIngredientsByRecipeId(recipesProp.id)" role="button" class="mt-5 rounded"
        data-bs-toggle="modal" data-bs-target="#recipeDetailsModal">
        <div>
            <p class="fw-bold bg-success m-0 text-white text-center fs-3 p-1 rounded-top">{{ recipesProp.category }}</p>
        </div>
        <div>
            <img :src="recipesProp.img" :alt="recipesProp.title">
        </div>
        <div>
            <p class="fw-bold bg-success text-white text-center rounded-bottom">{{ recipesProp.title }}</p>
        </div>
    </div>
</template>


<script>
import { AppState } from '../AppState';
import { computed, reactive, onMounted } from 'vue';
import { Recipe } from '../models/Recipe';
import Pop from '../utils/Pop';
import { recipesService } from '../services/RecipesService';
export default {
    props: { recipesProp: { type: Recipe, required: true } },

    setup() {

        return {
            async getRecipeById(recipeId) {
                try {
                    const recipe = await recipesService.getRecipeById(recipeId)
                    return recipe
                } catch (error) {
                    Pop.error(error)
                }
            },

            async getIngredientsByRecipeId(recipeId) {
                try {
                    const recipeIngredients = await recipesService.getIngredientsByRecipeId(recipeId)
                    return recipeIngredients
                } catch (error) {
                    Pop.error(error)
                }
            },

        }

    }
};
</script>


<style lang="scss" scoped>
img {
    height: 40vh;
    width: 100%;
    object-fit: cover;
}
</style>