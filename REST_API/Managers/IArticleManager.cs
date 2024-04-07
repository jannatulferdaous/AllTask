using REST_API.Models;
using REST_API.Response;

namespace REST_API.Managers
{
    public interface IArticleManager
    {
        Task<PagedResponse<Article>> GetAllArticles();
        Task<Article> GetArticleById(int id);
        Task<Article> UpdateArticle(int id, Article article);
        Task<Article> CreateArticle(Article article);
        Task DeleteArticle(int id);
        Task<Article>Index(int id);
    }
}
