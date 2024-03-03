using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using REST_API.DataLayer;
using REST_API.Models;

namespace REST_API.Services
{
    public class ArticleRepository : IArticleRepository
    {
        private readonly DataContext _context;

        public ArticleRepository(DataContext context)
        {
            _context = context;
        }
        async Task<List<Article>> IArticleRepository.GetAllArticles()
        {
            return await _context.Articles.ToListAsync();
        }

        async Task<Article> IArticleRepository.GetArticleById(int id)
        {
            return await _context.Articles.FindAsync(id);
        }

        public  async Task<Article> UpdateArticle(int id, Article article)
        {
            var existingArticle = await _context.Articles.FindAsync(id);
            if (existingArticle == null)
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

        async public Task<Article> CreateArticle(Article article)
        {
            _context.Articles.Add(article);
            await _context.SaveChangesAsync();
            return article;
        }

       async Task IArticleRepository.DeleteArticle(int id)
        {
            var article = await _context.Articles.FindAsync(id);
            if (article == null)
            {
                return;
            }
            _context.Articles.Remove(article);
            await _context.SaveChangesAsync();
        }

         
    }
}
