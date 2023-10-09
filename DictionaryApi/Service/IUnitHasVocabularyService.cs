using DictionaryApi.Domain;

namespace DictionaryApi.Service
{
    public interface IUnitHasVocabularyService
    {
        Task<UnitHasVocabulary> AddUnitHasVocabularyAsync(UnitHasVocabulary obj);
        Task<IEnumerable<UnitHasVocabulary>> GetAllVocabularyOfUnitAsync(string unitId);
        Task<bool> RemoveUnitHasVocabularyAsync(string id);
    }
}
