using REST_API.Models;

namespace REST_API.Services
{
    public interface IQsnViewService
    {
        Task<List<QuestionViewPage>> Index(int id);       
        Task SaveAnswers(List<QuestionAnswerMap> questionViewPages);
    }
}