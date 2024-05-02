using REST_API.Models;

namespace REST_API.Managers
{
    public interface IUserResultManager
    {
        Task<int> GetResult(int id);
        Task NextArticle(QuestionAnswerMap questionAnswerMap);
    }
}