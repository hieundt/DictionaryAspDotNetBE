using DictionaryApi.Domain;

namespace DictionaryApi.Service
{
    public interface ITestHistoryService
    {
        Task<TestHistory> AddTestHistoryAsync(TestHistory obj);
        Task<IEnumerable<TestHistory>> GetAllTestHistoryOfUserAsync(string userId);
        Task<bool> RemoveTestHistoryAsync(string id);
    }
}
