using Microsoft.EntityFrameworkCore;
using REST_API.DataLayer;
using REST_API.Models;

namespace REST_API.Services
{
    public class UserResultService : IUserResultService
    {
        public readonly DataContext _context;
        public UserResultService(DataContext context)
        {
            _context = context;
        }
        public async Task<int> GetResult(int id)
        {
            try
            {

                var correctAnswerCount = await (
                    from qAnswer in _context.Answers
                    join qaMap in _context.QuestionAnswerMaps
                        on qAnswer.Id equals qaMap.AnswerId
                    where qAnswer.IsCorrect == true && qaMap.UserId == id
                    select qAnswer
                ).CountAsync();
                return correctAnswerCount;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error getting user result: {ex.Message}");
                throw;
            }
        }

        public async Task NextArticle(QuestionAnswerMap questionAnswerMap)
        {
            try
            {
                int nextId;
                var id = questionAnswerMap.UserId;
                var existingUser = await _context.UserArticles.FirstOrDefaultAsync(ua => ua.UserId == id);
                if (existingUser != null)
                {
                    var greaterArticleId = _context.Articles.Where(ar => ar.ArticleId > questionAnswerMap.ArticleId)/*.FirstOrDefault()*/;
                    if (greaterArticleId.Any())
                    {
                        nextId = await greaterArticleId.MinAsync(t => t.ArticleId);
                    }
                    else
                    {
                        nextId = await _context.Articles.MinAsync(t => t.ArticleId);
                    }
                    existingUser.ArticleId = nextId;
                    await _context.SaveChangesAsync();
                    return;
                }
               
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error getting user result: {ex.Message}");
                throw;
            }
        }
    }
}
