using REST_API.Models;
using REST_API.Response;

namespace REST_API.Services
{
    public interface IQuestionService
    {
        Task<PagedResponse<Question>> GetAllQuestions();
        Task<Question> GetQuestionById(int id);
        Task<Question> UpdateQuestion(int id, Question question);
        Task<Question> CreateQuestion(Question question);
        Task DeleteQuestion(int id);
    }
}
