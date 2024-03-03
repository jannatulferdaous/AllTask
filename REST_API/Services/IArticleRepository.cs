using REST_API.Models;

namespace REST_API.Services
{
    public interface IArticleRepository
    {
        Task<List<Article>> GetAllArticles();
        Task<Article> GetArticleById(int id);
        Task<Article> UpdateArticle(int id,Article article);
        Task<Article> CreateArticle(Article article);
        Task DeleteArticle(int id);
    }
}
