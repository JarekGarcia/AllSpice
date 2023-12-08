import { AppState } from "../AppState"
import { Ingredient } from "../models/Ingredient"
import { Recipe } from "../models/Recipe"
import { logger } from "../utils/Logger"
import { api } from "./AxiosService"

class RecipesService {
    async GetRecipes() {
        const res = await api.get('api/recipes')
        AppState.recipes = res.data.map((recipe) => new Recipe(recipe))
    }

    async getRecipeById(recipeId) {
        const res = await api.get(`api/recipes/${recipeId}`)
        AppState.activeRecipe = res.data
    }

    async getIngredientsByRecipeId(recipeId) {
        const res = await api.get(`api/recipes/${recipeId}/ingredients`)
        AppState.activeIngredients = res.data.map((ingredients) => new Ingredient(ingredients))
    }

    clearActiveRecipe() {
        AppState.activeRecipe = null
        AppState.activeIngredients = null
        logger.log(AppState.activeRecipe)

    }
}

export const recipesService = new RecipesService()