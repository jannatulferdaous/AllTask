using Microsoft.EntityFrameworkCore;
using REST_API.DataLayer;
using REST_API.Models;

namespace REST_API.Services
{
    public class QsnViewService : IQsnViewService
    {
        public readonly DataContext _context;
        public QsnViewService(DataContext context)
        {
            _context = context;
        }

        public async Task<List<QuestionViewPage>> Index(int id)
        {
            try
            {
                var query = from article in _context.Articles
                            join question in _context.Questions on article.ArticleId equals question.ArticleId
                            join answer in _context.Answers on question.Id equals answer.QuestionId
                            where article.ArticleId == id
                            orderby question.Id, answer.Id
                            select new QuestionViewPage
                            {
                                ArticleId = article.ArticleId,
                                Question = question.QuestionText,
                                QuestionId = question.Id,
                                Answers = new List<AnswerView>
                                 {
                                    new AnswerView
                                    {
                                        Answer = answer.Answer,
                                        AnswerId = answer.Id,
                                        IsCorrect = answer.IsCorrect
                                    }
                                 }
                            };

                return await query.ToListAsync();

            }
            catch (Exception ex)
            {

                return null;
            }
        }
    }
}
