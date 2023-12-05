


namespace AllSpice.Services;

public class IngredientsService
{

    private readonly IngredientsRepository _repository;

    public IngredientsService(IngredientsRepository repository)
    {
        _repository = repository;
    }

    internal Ingredient CreateIngredient(Ingredient ingredientData)
    {
        Ingredient ingredient = _repository.CreateIngredient(ingredientData);
        return ingredient;
    }

    internal string DeleteIngredient(int ingredientId, string userId)
    {
        Ingredient ingredient = GetIngredientById(ingredientId);
        if (userId != ingredient.CreatorId)
        {
            throw new Exception($"{ingredient.Name} is not your ingredient to delete!");
        }
        _repository.DeleteIngredient(ingredientId);
        return "Ingredient was deleted!";

    }

    internal Ingredient GetIngredientById(int ingredientId)
    {
        Ingredient ingredient = _repository.GetIngredientById(ingredientId);

        if (ingredient == null)
        {
            throw new Exception($"Invalid Id: {ingredientId}");
        }

        return ingredient;
    }

    internal List<Ingredient> GetIngredientsByRecipeId(int recipeId)
    {
        List<Ingredient> ingredients = _repository.GetIngredientsByRecipeId(recipeId);
        return ingredients;
    }
}