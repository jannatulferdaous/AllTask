using REST_API.Models;

namespace REST_API.Services
{
    public interface IUserResultService
    {
        Task<int> GetResult(int id);
        Task NextArticle(QuestionAnswerMap questionAnswerMap);
    }
}