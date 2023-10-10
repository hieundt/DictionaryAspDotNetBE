using DictionaryApi.Domain;

namespace DictionaryApi.Service
{
    public interface IOptionService
    {
        Task<Option> AddOptionAsync(Option obj);
        Task<IEnumerable<Option>> GetAllOptionAsync();
        Task<Option> GetOptionByIdAsync(string id);
        Task<bool> RemoveOptionAsync(string id);
    }
}
