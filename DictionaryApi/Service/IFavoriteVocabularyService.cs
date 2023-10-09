using DictionaryApi.Domain;

namespace DictionaryApi.Service
{
    public interface IFavoriteVocabularyService
    {
        Task<FavoriteVocabulary> AddFavoriteVocabularyAsync(FavoriteVocabulary obj);
        Task<IEnumerable<FavoriteVocabulary>> GetAllFavoriteVocabularyOfUserAsync(string userId);
        Task<bool> RemoveFavoriteVocabularyAsync(string id);
    }
}
