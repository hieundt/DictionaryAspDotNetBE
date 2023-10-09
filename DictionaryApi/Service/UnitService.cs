using DictionaryApi.Domain;
using DictionaryApi.Repository;

namespace DictionaryApi.Service
{
    public class UnitService : IUnitService
    {
        private readonly IMongoRepository<Unit> _unitRepository;
        public UnitService(IMongoRepository<Unit> unitRepository)
        {
            _unitRepository = unitRepository;
        }
        public async Task<Unit> AddUnitAsync(Unit obj)
        {
            return await _unitRepository.Add(obj);
        }
        public async Task<IEnumerable<Unit>> GetAllUnitAsync()
        {
            return await _unitRepository.GetAll();
        }

        public async Task<Unit> GetUnitByIdAsync(string id)
        {
            var existing = await _unitRepository.GetById(id);
            if (existing == null)
            {
                throw new KeyNotFoundException($"Entity not found");
            }
            return existing;
        }
        public async Task<Unit> UpdateUnitAsync(string id, Unit obj)
        {
            var existing = await _unitRepository.GetById(id);
            if (existing == null)
            {
                throw new KeyNotFoundException($"Entity not found");
            }
            existing.Name = string.IsNullOrEmpty(obj.Name) ? existing.Name : obj.Name;
            existing.Image = string.IsNullOrEmpty(obj.Image) ? existing.Image : obj.Image;
            return await _unitRepository.Update(id, existing);
        }
        public async Task<bool> RemoveUnitAsync(string id)
        {
            var existing = await _unitRepository.GetById(id);
            if (existing == null)
            {
                throw new KeyNotFoundException($"Entity not found");
            }
            return await _unitRepository.Remove(id);
        }

    }
}
