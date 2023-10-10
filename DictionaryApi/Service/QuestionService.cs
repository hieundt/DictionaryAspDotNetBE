using DictionaryApi.Domain;
using DictionaryApi.Repository;

namespace DictionaryApi.Service
{
    public class QuestionService : IQuestionService
    {
        private readonly IMongoRepository<Question> _questionRepository;
        public QuestionService(IMongoRepository<Question> questionRepository)
        {
            _questionRepository = questionRepository;
        }
        public async Task<Question> AddQuestionAsync(Question obj)
        {
            return await _questionRepository.Add(obj);
        }
        public async Task<IEnumerable<Question>> GetAllQuestionAsync()
        {
            return await _questionRepository.GetAll();  
        }
        public async Task<Question> GetQuestionByIdAsync(string id)
        {
            var existing = await _questionRepository.GetById(id);
            if (existing == null)
            {
                throw new KeyNotFoundException($"Entity not found");
            }
            return existing;
        }
        public async Task<Question> UpdateQuestionAsync(string id, Question obj)
        {
            var existing = await _questionRepository.GetById(id);
            if (existing == null)
            {
                throw new KeyNotFoundException($"Entity not found");
            }
            existing.Type = obj.Type == null ? existing.Type : obj.Type;
            existing.Title = string.IsNullOrEmpty(obj.Title) ? existing.Title : obj.Title;
            existing.Description= string.IsNullOrEmpty(obj.Description) ? existing.Description : obj.Description;
            existing.Answer= string.IsNullOrEmpty(obj.Answer) ? existing.Answer : obj.Answer;
            existing.Point = obj.Point == null ? existing.Point : obj.Point;
            existing.Options = obj.Options == null ? existing.Options: obj.Options;
            return await _questionRepository.Update(id, existing);
        }
        public async Task<bool> RemoveQuestionAsync(string id)
        {
            var existing = await _questionRepository.GetById(id);
            if (existing == null)
            {
                throw new KeyNotFoundException($"Entity not found");
            }
            return await _questionRepository.Remove(id);
        }

      
    }
}
