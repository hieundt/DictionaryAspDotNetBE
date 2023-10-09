using DictionaryApi.Domain;

namespace DictionaryApi.Service
{
    public interface IUserService
    {
        Task<User> AddUserAsync(User obj);
        Task<IEnumerable<User>> GetAllUserAsync();
        Task<User> GetUserByIdAsync(string id);
        Task<User> UpdateUserAsync(string id, User obj);
        Task<bool> RemoveUserAsync(string id);
        Task<User> SignIn(string email, string password);
    }
}
