using DictionaryApi.Domain;

namespace DictionaryApi.Service
{
    public interface IQuestionService
    {
        Task<Question> AddQuestionAsync(Question obj);
        Task<IEnumerable<Question>> GetAllQuestionAsync();
        Task<Question> GetQuestionByIdAsync(string id);
        Task<Question> UpdateQuestionAsync(string id, Question obj);
        Task<bool> RemoveQuestionAsync(string id);
    }
}
