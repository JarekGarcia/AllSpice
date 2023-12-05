



using Microsoft.AspNetCore.Http.HttpResults;

namespace AllSpice.Services;

public class RecipesService
{
    private readonly RecipesRepository _repository;

    public RecipesService(RecipesRepository repository)
    {
        _repository = repository;
    }

    internal Recipe CreateRecipe(Recipe recipeData)
    {
        Recipe recipe = _repository.CreateRecipe(recipeData);
        return recipe;
    }

    internal string DeleteRecipe(int recipeId, string userId)
    {
        Recipe recipe = GetRecipeById(recipeId);
        if (recipe == null)
        {
            throw new Exception($"Invalid Id:{recipeId}");
        }

        if (recipe.CreatorId != userId)
        {
            throw new Exception("Not your Recipe to delete");
        }


        _repository.DeleteRecipe(recipeId);
        return $"{recipe.Title} has been deleted!";
    }

    internal Recipe EditRecipe(Recipe recipeData, string userId, int recipeId)
    {
        Recipe ogRecipe = GetRecipeById(recipeId);

        if (ogRecipe.CreatorId != userId)
        {
            throw new Exception("This is not your Recipe to edit");
        }

        ogRecipe.Title = recipeData.Title ?? ogRecipe.Title;
        ogRecipe.Category = recipeData.Category ?? ogRecipe.Category;
        ogRecipe.Img = recipeData.Img ?? ogRecipe.Img;
        ogRecipe.Instructions = recipeData.Instructions ?? ogRecipe.Instructions;

        _repository.EditRecipe(ogRecipe);
        return ogRecipe;
    }


    internal Recipe GetRecipeById(int recipeId)
    {
        Recipe recipe = _repository.GetRecipeById(recipeId);

        if (recipe == null)
        {
            throw new Exception($"Invalid id: {recipe.Id}");
        }
        return recipe;
    }

    internal List<Recipe> GetRecipes()
    {
        List<Recipe> recipes = _repository.GetRecipes();
        return recipes;
    }
}