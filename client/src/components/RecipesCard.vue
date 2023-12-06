<template>
    <div class="mt-5" data-bs-toggle="modal" data-bs-target="#recipeDetailsModal">
        <div>
            <p class="fw-bold bg-success m-0 text-white text-center fs-3 p-1">{{ recipesProp.category }}</p>
        </div>
        <div>
            <img :src="recipesProp.img" :alt="recipesProp.title">
        </div>
        <div>
            <p class="fw-bold bg-success text-white text-center">{{ recipesProp.title }}</p>
        </div>
    </div>
</template>


<script>
import { AppState } from '../AppState';
import { computed, reactive, onMounted } from 'vue';
import { Recipe } from '../models/Recipe';
export default {
    props: { recipesProp: { type: Recipe, required: true } },

    setup() {

        return {



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