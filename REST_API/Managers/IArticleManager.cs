using REST_API.Models;
using REST_API.Response;

namespace REST_API.Managers
{
    public interface IArticleManager
    {
        Task<PagedResponse<Article>> GetAllArticles();
    }
}
