using DictionaryApi.Domain;
using DictionaryApi.Repository;
using Microsoft.AspNetCore.Mvc;

namespace DictionaryApi.Service
{
    public class VocabularyService : IVocabularyService
    {
        private readonly IMongoRepository<Vocabulary> _vocabularyRepository;
        public VocabularyService(IMongoRepository<Vocabulary> vocabularyRepository)
        {
            _vocabularyRepository = vocabularyRepository;
        }
        public async Task<Vocabulary> AddVocabularyAsync(Vocabulary obj)
        {
            return await _vocabularyRepository.Add(obj);
        }
        public async Task<IEnumerable<Vocabulary>> GetAllVocabularyAsync()
        {
            return await _vocabularyRepository.GetAll();
        }
        public async Task<Vocabulary> GetVocabularyByIdAsync(string id)
        {
            var existing = await _vocabularyRepository.GetById(id);
            if (existing == null)
            {
                throw new KeyNotFoundException($"Entity not found");
            }
            return existing;
        }
        public async Task<Vocabulary> UpdateVocabularyAsync(string id, Vocabulary obj)
        {
            var existing = await _vocabularyRepository.GetById(id);
            if (existing == null)
            {
                throw new KeyNotFoundException($"Entity not found");
            }
            existing.Type = string.IsNullOrEmpty(obj.Type) ? existing.Type : obj.Type;
            existing.Word = string.IsNullOrEmpty(obj.Word) ? existing.Word : obj.Word;
            existing.Hint = string.IsNullOrEmpty(obj.Hint) ? existing.Hint : obj.Hint;
            existing.Phonetics = string.IsNullOrEmpty(obj.Phonetics) ? existing.Phonetics : obj.Phonetics;
            existing.Pronouce = string.IsNullOrEmpty(obj.Pronouce) ? existing.Pronouce : obj.Pronouce;
            existing.Image = string.IsNullOrEmpty(obj.Image) ? existing.Image : obj.Image;
            existing.Meaning = string.IsNullOrEmpty(obj.Meaning) ? existing.Meaning : obj.Meaning;
            return await _vocabularyRepository.Update(id, existing);
        }
        public async Task<bool> RemoveVocabularyAsync(string id)
        {
            var existing = await _vocabularyRepository.GetById(id);
            if (existing == null)
            {
                throw new KeyNotFoundException($"Entity not found");
            }
            return await _vocabularyRepository.Remove(id);
        }

      
    }
}

