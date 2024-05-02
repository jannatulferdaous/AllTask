using Microsoft.AspNetCore.Http.HttpResults;
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
        public async Task SaveAnswers(List<QuestionAnswerMap> questionAnswerMap)
        {
            try
            {
                foreach (var item in questionAnswerMap)
                {
                    var existingQsn = await _context.QuestionAnswerMaps.FirstOrDefaultAsync(ob => ob.UserId == item.UserId && ob.QuestionId == item.QuestionId);
                    if (existingQsn != null)
                    {
                        existingQsn.UserId = item.UserId;
                        existingQsn.QuestionId = item.QuestionId;
                        existingQsn.AnswerId = item.AnswerId;
                        existingQsn.ArticleId = item.ArticleId;
                    }
                    else
                    {
                        _context.QuestionAnswerMaps.Add(item);
                    }
                }
                await _context.SaveChangesAsync();
                return ;
            }
            catch (Exception ex)
            {
                
            }


        

        }

    }
}
