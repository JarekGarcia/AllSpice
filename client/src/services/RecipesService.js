import { AppState } from "../AppState"
import { Recipe } from "../models/Recipe"
import { logger } from "../utils/Logger"
import { api } from "./AxiosService"

class RecipesService {
    async GetRecipes() {
        const res = await api.get('api/recipes')
        logger.log('[recipes]', res.data)
        AppState.recipes = res.data.map((recipe) => new Recipe(recipe))
    }

    async getRecipeById(recipeId) {
        const res = await api.get(`api/recipes/${recipeId}`)
        logger.log("[recipe]", res.data)
    }
}

export const recipesService = new RecipesService()