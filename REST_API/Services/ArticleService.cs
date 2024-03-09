using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using REST_API.DataLayer;
using REST_API.Models;
using REST_API.Response;

namespace REST_API.Services
{
    public class ArticleService : IArticleService
    {
        private readonly DataContext _context;

        public ArticleService(DataContext context)
        {
            _context = context;
        }

        public async Task<Article> CreateArticle(Article article)
        {
            _context.Articles.Add(article);
            await _context.SaveChangesAsync();
            return article;
        }

        public async Task DeleteArticle(int id)
        {
            var article = await _context.Articles.FindAsync(id);
            if (article is null)
            {
                return;
            }
            _context.Articles.Remove(article);
            await _context.SaveChangesAsync();
        }

        public async Task<PagedResponse<Article>> GetAllArticles()
        {

            IEnumerable<Article> articles = [];

            articles = await _context.Articles.ToListAsync();

            if (articles is null || articles.Count() <= 0)
            {
                
                return new PagedResponse<Article>
                {
                    Data = [],
                    TotalCount = 0,
                    IsSuccess = articles is null ? false : true,
                    Message = "No Articles Found"
                };
            }

            return new PagedResponse<Article>
            {
                Data = articles,
                TotalCount = articles.Count(),
                IsSuccess = true,
                Message = string.Empty
            };

        }      

        public  async Task<Article> UpdateArticle(int id, Article article)
        {
            var existingArticle = await _context.Articles.FindAsync(id);
            if (existingArticle is null)
            {
                return null;
            }
            existingArticle.Title = article.Title;
            existingArticle.Language = article.Language;
            existingArticle.ArticleText = article.ArticleText;
            _context.Articles.Update(existingArticle);
            await _context.SaveChangesAsync();
            return existingArticle;
        }

        public async  Task<Article> GetArticleById(int id)
        {
            var article = await _context.Articles.FindAsync(id);
            return article;
        }

        // public  async Task<Article> UpdateArticle(int id, Article article)
        // {
        //     var existingArticle = await _context.Articles.FindAsync(id);
        //     if (existingArticle == null)
        //     {
        //         return null;
        //     }
        //     existingArticle.Title = article.Title;
        //     existingArticle.Language = article.Language;
        //     existingArticle.ArticleText = article.ArticleText;

        //     _context.Articles.Update(existingArticle);
        //     await _context.SaveChangesAsync();
        //     return existingArticle;
        // }

        // async public Task<Article> CreateArticle(Article article)
        // {
        //     _context.Articles.Add(article);
        //     await _context.SaveChangesAsync();
        //     return article;
        // }

        //async Task IArticleService.DeleteArticle(int id)
        // {
        //     var article = await _context.Articles.FindAsync(id);
        //     if (article == null)
        //     {
        //         return;
        //     }
        //     _context.Articles.Remove(article);
        //     await _context.SaveChangesAsync();
        // }


    }
}
