using DictionaryApi.Domain;
using DictionaryApi.Repository;

namespace DictionaryApi.Service
{
    public class UserService : IUserService
    {
        private readonly IMongoRepository<User> _userRepository;    
        public UserService(IMongoRepository<User> userRepository) 
        {
            _userRepository = userRepository;
        }
        public async Task<User> AddUserAsync(User obj)
        {
            return await _userRepository.Add(obj);
        }
        public async Task<IEnumerable<User>> GetAllUserAsync()
        {
           return await _userRepository.GetAll();   
        }
        public async Task<User> GetUserByIdAsync(string id)
        {
            var existing = await _userRepository.GetById(id);
            if (existing == null) 
            {
                throw new KeyNotFoundException($"Entity not found");
            }
            return existing;
        }
        public async Task<User> UpdateUserAsync(string id, User obj)
        {
            var existing = await _userRepository.GetById(id);
            if (existing == null)
            {
                throw new KeyNotFoundException($"Entity not found");
            }
            existing.Email = string.IsNullOrEmpty(obj.Email) ? existing.Email : obj.Email;
            existing.PassWord = string.IsNullOrEmpty(obj.PassWord) ? existing.PassWord : obj.PassWord;
            existing.UserName = string.IsNullOrEmpty(obj.UserName) ? existing.UserName : obj.UserName;
            existing.DateOfBirth = obj.DateOfBirth == null ? existing.DateOfBirth : obj.DateOfBirth;
            return existing;
        }
        public async Task<bool> RemoveUserAsync(string id)
        {
            var existing = await _userRepository.GetById(id);
            if (existing == null)
            {
                throw new KeyNotFoundException($"Entity not found");
            }
            return await _userRepository.Remove(id);
        }

        public Task<User> SignIn(string email, string password)
        {
            throw new NotImplementedException();
        }
    }
}
