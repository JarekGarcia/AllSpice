



namespace AllSpice.Repositories;

public class IngredientsRepository
{

    private readonly IDbConnection _db;

    public IngredientsRepository(IDbConnection db)
    {
        _db = db;
    }

    internal Ingredient CreateIngredient(Ingredient ingredientData)
    {
        string sql = @"
        INSERT INTO
        ingredients(name, quantity, recipeId, creatorId)
        VALUES(@Name, @Quantity, @RecipeId, @CreatorId);

        SELECT 
        ind.*,
        acc.*,
        rec.*
        FROM ingredients ind 
        JOIN accounts acc ON acc.id = ind.creatorId
        JOIN recipes rec ON rec.id = ind.recipeId
        WHERE ind.id = LAST_INSERT_ID();";

        Ingredient ingredient = _db.Query<Ingredient, Profile, Recipe, Ingredient>(sql, (ingredient, profile, recipe) =>
        {
            ingredient.Creator = profile;
            ingredient.Recipe = recipe;
            ingredient.Recipe.Creator = recipe.Creator;
            return ingredient;
        }, ingredientData).FirstOrDefault();
        return ingredient;
    }

    internal void DeleteIngredient(int ingredientId)
    {
        string sql = @"
        DELETE FROM ingredients WHERE id = @ingredientId LIMIT 1;";

        _db.Execute(sql, new { ingredientId });
    }

    internal Ingredient GetIngredientById(int ingredientId)
    {
        string sql = @"
        SELECT 
        ing.*,
        acc.*
        FROM ingredients ing 
        JOIN accounts acc ON acc.id = ing.creatorId
        WHERE ing.id = @ingredientId
        ;";

        Ingredient ingredient = _db.Query<Ingredient, Profile, Ingredient>(sql, (ingredient, profile) =>
        {
            ingredient.Creator = profile;
            return ingredient;
        }, new { ingredientId }).FirstOrDefault();
        return ingredient;
    }

    internal List<Ingredient> GetIngredientsByRecipeId(int recipeId)
    {
        string sql = @"
        SELECT 
        ing.*,
        acc.*,
        rec.*
        FROM ingredients ing 
        JOIN accounts acc ON acc.id = ing.creatorId
        JOIN recipes rec ON rec.id = ing.recipeId
        WHERE ing.recipeId = @recipeId;";

        List<Ingredient> ingredients = _db.Query<Ingredient, Profile, Recipe, Ingredient>(sql, (ingredients, profile, recipe) =>
        {
            ingredients.Creator = profile;
            ingredients.Recipe = recipe;
            ingredients.Recipe.Creator = recipe.Creator;
            return ingredients;
        }, new { recipeId }).ToList();
        return ingredients;
    }
}