using DictionaryApi.Domain;
using DictionaryApi.Repository;

namespace DictionaryApi.Service
{
    public class TestService : ITestService
    {
        private readonly IMongoRepository<Test> _testRepository;
        public TestService(IMongoRepository<Test> testRepository)
        {
            _testRepository = testRepository;
        }
        public async Task<Test> AddTestAsync(Test obj)
        {
           return await _testRepository.Add(obj);   
        }
        public async Task<IEnumerable<Test>> GetAllTestAsync()
        {
           return await _testRepository.GetAll();   
        }
        public Task<Test> GetTestByIdAsync(string id)
        {
            var existing = _testRepository.GetById(id);
            if (existing == null)
            {
                throw new KeyNotFoundException($"Entity not found");
            }
            return existing;
        }
        public async Task<Test> UpdateTestAsync(string id, Test obj)
        {
            var existing = await  _testRepository.GetById(id);
            if (existing == null)
            {
                throw new KeyNotFoundException($"Entity not found");
            }
            existing.Name = string.IsNullOrEmpty(obj.Name) ? existing.Name : obj.Name;
            existing.Image = obj.Image == null ? existing.Image : obj.Image;
            existing.Questions = obj.Questions == null ? existing.Questions : obj.Questions;
            return await _testRepository.Update(id, existing);
        }
        public async Task<bool> RemoveTestAsync(string id)
        {
            var existing = _testRepository.GetById(id);
            if (existing == null)
            {
                throw new KeyNotFoundException($"Entity not found");
            }
            return await _testRepository.Remove(id);
        }
    }
}
