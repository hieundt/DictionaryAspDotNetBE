using DictionaryApi.Domain;
using DictionaryApi.Repository;

namespace DictionaryApi.Service
{
    public class TestHistoryService : ITestHistoryService
    {
        private readonly IMongoRepository<TestHistory> _testHistoryRepostory;
        public TestHistoryService(IMongoRepository<TestHistory> testHistoryRepostory)
        {
            _testHistoryRepostory = testHistoryRepostory;
        }
        public async Task<TestHistory> AddTestHistoryAsync(TestHistory obj)
        {
            return await _testHistoryRepostory.Add(obj);
        }
        public async Task<IEnumerable<TestHistory>> GetAllTestHistoryOfUserAsync(string userId)
        {
            var allData = await _testHistoryRepostory.GetAll();
            var filter = allData.Where(item => item.UserId == userId);
            return filter;
        }
        public async Task<bool> RemoveTestHistoryAsync(string id)
        {
            var existing = _testHistoryRepostory.GetById(id);
            if (existing == null)
            {
                throw new KeyNotFoundException($"Entity not found");
            }
            return await _testHistoryRepostory.Remove(id);
        }
    }
}
