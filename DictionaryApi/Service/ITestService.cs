using DictionaryApi.Domain;

namespace DictionaryApi.Service
{
    public interface ITestService
    {
        Task<Test> AddTestAsync(Test obj);
        Task<IEnumerable<Test>> GetAllTestAsync();
        Task<Test> GetTestByIdAsync(string id);
        Task<Test> UpdateTestAsync(string id, Test obj);
        Task<bool> RemoveTestAsync(string id);
    }
}
