using System.Security.Cryptography;
using System.Text;
using DictionaryApi.Domain;
using DictionaryApi.Repository;
using MongoDB.Driver.Linq;

namespace DictionaryApi.Service
{
    public class UserService : IUserService
    {
        private readonly IMongoRepository<User> _userRepository;    
        public UserService(IMongoRepository<User> userRepository) 
        {
            _userRepository = userRepository;
        }
        public async Task<User> AddUserByEmailPasswordAsync(User obj)
        {
            obj.Password = ToHexString(GetSHA(obj.Password));
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
            existing.Password = string.IsNullOrEmpty(obj.Password) ? existing.Password : obj.Password;
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
        public async Task<User?> EmailPasswordSignInAsync(string email, string password)
        {
            var allUser = await _userRepository.GetAll();
            var existUser = allUser.Single(item => item.Email == email);
            if(existUser !=  null)
            {
                string hexInput = ToHexString(GetSHA(password));
                if (existUser.Password.Equals(hexInput))
                {
                    return existUser;
                }
                return null;
            }
            throw new KeyNotFoundException($"Entity not found");
        }
        public static byte[] GetSHA(string input)
        {
            // Create an instance of the SHA-256 hash algorithm
            using (SHA256 sha256 = SHA256.Create())
            {
                // Compute the hash of the input string
                byte[] hashBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(input));
                return hashBytes;
            }
        }
        public static string ToHexString(byte[] hash)
        {
            // Convert the byte array to a hexadecimal string
            StringBuilder hexString = new StringBuilder(hash.Length * 2);
            foreach (byte b in hash)
            {
                hexString.Append(b.ToString("x2"));
            }
            return hexString.ToString();
        }
    }
}
