using DictionaryApi.Domain;

namespace DictionaryApi.Service
{
    public interface IUnitService
    {
        Task<Unit> AddUnitAsync(Unit obj);
        Task<IEnumerable<Unit>> GetAllUnitAsync();
        Task<Unit> GetUnitByIdAsync(string id);
        Task<Unit> UpdateUnitAsync(string id, Unit obj);
        Task<bool> RemoveUnitAsync(string id);
    }
}
