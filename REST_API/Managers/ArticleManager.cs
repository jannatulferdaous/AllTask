using REST_API.Models;
using REST_API.Response;
using REST_API.Services;

namespace REST_API.Managers
{
    public class ArticleManager : IArticleManager
    {
        private readonly IArticleService _articleService;
        public ArticleManager(IArticleService articleService)
        {
            _articleService = articleService;
        }

        public async Task<Article> CreateArticle(Article article)
        {
            return await _articleService.CreateArticle(article);
        }

        public async Task DeleteArticle(int id)
        {
             await _articleService.DeleteArticle(id);
        }

        public async Task<PagedResponse<Article>> GetAllArticles()
        {
            return await _articleService.GetAllArticles();
        }

        public async Task<Article> GetArticleById(int id)
        {
            return await _articleService.GetArticleById(id);
        }

        public async Task<Article> UpdateArticle(int id, Article article)
        {
            return await _articleService.UpdateArticle(id,article);
        }
    }
}
