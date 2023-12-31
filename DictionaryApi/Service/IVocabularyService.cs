﻿using DictionaryApi.Domain;

namespace DictionaryApi.Service
{
    public interface IVocabularyService
    {
        Task<Vocabulary> AddVocabularyAsync(Vocabulary obj);
        Task<IEnumerable<Vocabulary>> GetAllVocabularyAsync();
        Task<Vocabulary> GetVocabularyByIdAsync(string id);
        Task<Vocabulary> UpdateVocabularyAsync(string id, Vocabulary obj);
        Task<bool> RemoveVocabularyAsync(string id);
    }
}
