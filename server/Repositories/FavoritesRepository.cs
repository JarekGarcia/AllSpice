




namespace AllSpice.Repositories;

public class FavoritesRepository
{
    private readonly IDbConnection _db;

    public FavoritesRepository(IDbConnection db)
    {
        _db = db;
    }

    internal Favorite CreateFavorite(Favorite favoriteData)
    {
        string sql = @"
        INSERT INTO 
        favorites(recipeId, accountId)
        VALUES(@RecipeId, @AccountId);

        SELECT 
        fav.*,
        acc.*,
        rec.*
        FROM favorites fav 
        JOIN accounts acc ON acc.id = fav.accountId
        JOIN recipes rec ON rec.id = fav.recipeId
        WHERE fav.id = LAST_INSERT_ID()
        ;";

        Favorite favorite = _db.Query<Favorite, Profile, Recipe, Favorite>(sql, (favorite, profile, recipe) =>
        {
            favorite.Creator = profile;
            favorite.Recipe = recipe;
            favorite.Recipe.Creator = recipe.Creator;
            return favorite;
        }, favoriteData).FirstOrDefault();
        return favorite;
    }

    internal void DeleteFavorite(int favoriteId)
    {
        string sql = @"
        DELETE FROM favorites WHERE id = @favoriteId LIMIT 1;";

        _db.Execute(sql, new { favoriteId });
    }

    internal Favorite GetFavoriteById(int favoriteId)
    {
        string sql = "SELECT * FROM favorites WHERE id = @favoriteId";

        Favorite favorite = _db.Query<Favorite>(sql, new { favoriteId }).FirstOrDefault();
        return favorite;
    }

    internal List<Favorite> GetMyFavorites(string userId)
    {
        string sql = @"
        SELECT 
        fav.*,
        acc.*,
        rec.*
        FROM favorites fav 
        JOIN accounts acc ON acc.id = fav.accountId
        JOIN recipes rec ON rec.id = fav.recipeId
        WHERE fav.accountId = @userId
        ;";

        List<Favorite> favorites = _db.Query<Favorite, Profile, Recipe, Favorite>(sql, (favorite, profile, recipe) =>
        {
            favorite.Creator = profile;
            favorite.Recipe = recipe;
            favorite.Recipe.Creator = recipe.Creator;
            return favorite;
        }, new { userId }).ToList();
        return favorites;
    }
}