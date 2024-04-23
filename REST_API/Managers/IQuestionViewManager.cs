using REST_API.Models;

namespace REST_API.Managers
{
    public interface IQuestionViewManager
    {
        Task<List<QuestionViewPage>> Index(int id);
    }
}