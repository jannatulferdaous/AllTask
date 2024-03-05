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
        public async Task<PagedResponse<Article>> GetAllArticles()
        {
            return await _articleService.GetAllArticles();
        }
    }
}
