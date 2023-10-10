using DictionaryApi.Domain;
using DictionaryApi.Repository;

namespace DictionaryApi.Service
{
    public class OptionService : IOptionService
    {
        private readonly IMongoRepository<Option> _optionRepository;
        public OptionService(IMongoRepository<Option> optionRepository)
        {
            _optionRepository = optionRepository;
        }
        public async Task<Option> AddOptionAsync(Option obj)
        {
            return await _optionRepository.Add(obj);
        }
        public async Task<IEnumerable<Option>> GetAllOptionAsync()
        {
            return await _optionRepository.GetAll();
        }

        public async Task<Option> GetOptionByIdAsync(string id)
        {
            var existing = await _optionRepository.GetById(id);
            if (existing == null)
            {
                throw new KeyNotFoundException($"Entity not found");
            }
            return existing;
        }
        public async Task<bool> RemoveOptionAsync(string id)
        {
            var existing = await _optionRepository.GetById(id);
            if (existing == null)
            {
                throw new KeyNotFoundException($"Entity not found");
            }
            return await _optionRepository.Remove(id);
        }
    }
}
