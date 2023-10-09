using DictionaryApi.Domain;
using DictionaryApi.Repository;

namespace DictionaryApi.Service
{
    public class FavoriteUnitService : IFavoriteUnitService
    {
        private readonly IMongoRepository<FavoriteUnit> _favoriteUnitRepository;
        public FavoriteUnitService(IMongoRepository<FavoriteUnit> favoriteUnitRepository)
        {
            _favoriteUnitRepository = favoriteUnitRepository;
        }
        public async Task<FavoriteUnit> AddFavoriteUnitAsync(FavoriteUnit obj)
        {
            return await _favoriteUnitRepository.Add(obj);
        }
        public async Task<IEnumerable<FavoriteUnit>> GetAllFavoriteUnitOfUserAsync(string userId)
        {
            var allData = await _favoriteUnitRepository.GetAll();
            var filter = allData.Where(item => item.UserId == userId);
            return filter;
        }
        public async Task<bool> RemoveFavoriteUnitAsync(string id)
        {
            var existing = await _favoriteUnitRepository.GetById(id);
            if (existing == null)
            {
                throw new KeyNotFoundException($"Entity not found");
            }
            return await _favoriteUnitRepository.Remove(id);
        }
    }
}
