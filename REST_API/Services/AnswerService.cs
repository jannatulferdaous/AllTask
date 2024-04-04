using Microsoft.EntityFrameworkCore;
using REST_API.DataLayer;
using REST_API.Models;
using REST_API.Response;

namespace REST_API.Services
{
    public class AnswerService : IAnswerService
    {
        public readonly DataContext _context;
        public AnswerService(DataContext context)
        {
            _context = context;
        }
        public async Task<QAnswer> CreateAnswer(QAnswer answer)
        {
            _context.Answers.Add(answer);
            await _context.SaveChangesAsync();
            return answer;
        }

        public  async Task DeleteAnswer(int id)
        {
            var answer = await _context.Answers.FindAsync(id);
            if (answer is null)
            {
                return;
            }
            _context.Answers.Remove(answer);
            await _context.SaveChangesAsync();
        }

        public async Task<PagedResponse<QAnswer>> GetAllAnswers()
        {
            IEnumerable<QAnswer> answer = [];

            answer = await _context.Answers.ToListAsync();

            if (answer is null || answer.Count() <= 0)
            {

                return new PagedResponse<QAnswer>
                {
                    Data = [],
                    TotalCount = 0,
                    IsSuccess = answer is null ? false : true,
                    Message = "No Answer Found"
                };
            }

            return new PagedResponse<QAnswer>
            {
                Data = answer,
                TotalCount = answer.Count(),
                IsSuccess = true,
                Message = string.Empty
            };
        }

        public async Task<QAnswer> GetAnswerById(int id)
        {
            var answer = await _context.Answers.FindAsync(id);
            return answer is null ? null : answer;
        }

        public async Task<QAnswer> UpdateAnswer(int id, QAnswer answer)
        {
             var existingAnswer= await _context.Answers.FindAsync(id);
            if (existingAnswer is null)
            {
                return null;
            }
            existingAnswer.Answer = answer.Answer;
            existingAnswer.IsCorrect = answer.IsCorrect;
            existingAnswer.QuestionId = answer.QuestionId;
            await _context.SaveChangesAsync();
            return existingAnswer;
        }
    }
}
