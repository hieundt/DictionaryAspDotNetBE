using DictionaryApi.Domain;
using DictionaryApi.Repository;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace DictionaryApi.Service
{
    public class UnitHasVocabularyService : IUnitHasVocabularyService
    {
        private readonly IMongoRepository<UnitHasVocabulary> _unitVocaRepository;
        public UnitHasVocabularyService(IMongoRepository<UnitHasVocabulary> unitVocaRepository)
        {
            _unitVocaRepository = unitVocaRepository;
        }
        public async Task<UnitHasVocabulary> AddUnitHasVocabularyAsync(UnitHasVocabulary obj)
        {
           return await _unitVocaRepository.Add(obj);
        }
        public async Task<IEnumerable<UnitHasVocabulary>> GetAllVocabularyOfUnitAsync(string unitId)
        {
            var allData =  await _unitVocaRepository.GetAll();
            var filter = allData.Where(item => item.UnitId == unitId);
            return filter;    
        }
        public async Task<bool> RemoveUnitHasVocabularyAsync(string id)
        {
            var existing = await _unitVocaRepository.GetById(id);
            if (existing == null)
            {
                throw new KeyNotFoundException($"Entity not found");
            }
            return await _unitVocaRepository.Remove(id);
        }
     }
}
