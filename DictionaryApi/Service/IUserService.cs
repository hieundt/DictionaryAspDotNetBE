using DictionaryApi.Domain;

namespace DictionaryApi.Service
{
    public interface IUserService
    {
        Task<User> AddUserByEmailPasswordAsync(User obj);
        Task<IEnumerable<User>> GetAllUserAsync();
        Task<User> GetUserByIdAsync(string id);
        Task<User> UpdateUserAsync(string id, User obj);
        Task<bool> RemoveUserAsync(string id);
        Task<User?> EmailPasswordSignInAsync(string email, string password);
    }
}
