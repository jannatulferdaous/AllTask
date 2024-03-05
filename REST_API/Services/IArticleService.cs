using REST_API.Models;
using REST_API.Response;

namespace REST_API.Services
{
    public interface IArticleService
    {
        Task<PagedResponse<Article>> GetAllArticles();
        //Task<Article> GetArticleById(int id);
        //Task<Article> UpdateArticle(int id,Article article);
        //Task<Article> CreateArticle(Article article);
        //Task DeleteArticle(int id);
    }
}
