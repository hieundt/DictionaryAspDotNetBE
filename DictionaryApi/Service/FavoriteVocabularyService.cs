using DictionaryApi.Domain;
using DictionaryApi.Repository;

namespace DictionaryApi.Service
{
    public class FavoriteVocabularyService : IFavoriteVocabularyService
    {
        private readonly IMongoRepository<FavoriteVocabulary> _favoriteVocaRepository;
        public FavoriteVocabularyService(IMongoRepository<FavoriteVocabulary> favoriteVocaRepository)
        {
            _favoriteVocaRepository = favoriteVocaRepository;
        }
        public async Task<FavoriteVocabulary> AddFavoriteVocabularyAsync(FavoriteVocabulary obj)
        {
            return await _favoriteVocaRepository.Add(obj);
        }

        public async Task<IEnumerable<FavoriteVocabulary>> GetAllFavoriteVocabularyOfUserAsync(string userId)
        {
            var allData = await _favoriteVocaRepository.GetAll();
            var filter = allData.Where(item => item.UserId == userId);
            return filter;
        }

        public async Task<bool> RemoveFavoriteVocabularyAsync(string id)
        {
            var existing = await _favoriteVocaRepository.GetById(id);
            if (existing == null)
            {
                throw new KeyNotFoundException($"Entity not found");
            }
            return await _favoriteVocaRepository.Remove(id);
        }
    }
}
