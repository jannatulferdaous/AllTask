using REST_API.Models;
using REST_API.Response;

namespace REST_API.Managers
{
    public interface IAnswerManager
    {
        Task<PagedResponse<QAnswer>> GetAllAnswers();
        Task<QAnswer> GetAnswerById(int id);
        Task<QAnswer> UpdateAnswer(int id, QAnswer answer);
        Task<QAnswer> CreateAnswer(QAnswer answer);
        Task DeleteAnswer(int id);
    }
}
