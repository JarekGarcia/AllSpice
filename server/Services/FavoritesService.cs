


namespace AllSpice.Services;

public class FavoritesService
{
    private readonly FavoritesRepository _repository;

    public FavoritesService(FavoritesRepository repository)
    {
        _repository = repository;
    }

    internal Favorite CreateFavorite(Favorite favoriteData)
    {
        Favorite favorite = _repository.CreateFavorite(favoriteData);
        return favorite;
    }

    internal string DeleteFavorite(int favoriteId, string userId)
    {
        Favorite favorite = GetFavoriteById(favoriteId);
        if (favorite.AccountId != userId)
        {
            throw new Exception("Not your favorite to delete!");
        }
        _repository.DeleteFavorite(favoriteId);
        return "Favorite has been deleted";
    }

    internal Favorite GetFavoriteById(int favoriteId)
    {
        Favorite favorite = _repository.GetFavoriteById(favoriteId);
        if (favorite == null)
        {
            throw new Exception($"invalid Id: {favoriteId}");
        }
        return favorite;
    }

    internal List<Favorite> GetMyFavorites(string userId)
    {
        List<Favorite> favorite = _repository.GetMyFavorites(userId);
        return favorite;
    }
}