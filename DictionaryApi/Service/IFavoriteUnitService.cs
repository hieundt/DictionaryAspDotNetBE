using DictionaryApi.Domain;

namespace DictionaryApi.Service
{
    public interface IFavoriteUnitService
    {
        Task<FavoriteUnit> AddFavoriteUnitAsync(FavoriteUnit obj);
        Task<IEnumerable<FavoriteUnit>> GetAllFavoriteUnitOfUserAsync(string userId);
        Task<bool> RemoveFavoriteUnitAsync(string id);
    }
}
