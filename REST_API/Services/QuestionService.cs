using Microsoft.EntityFrameworkCore;
using REST_API.DataLayer;
using REST_API.Models;
using REST_API.Response;

namespace REST_API.Services
{
    public class QuestionService : IQuestionService
    {
        private readonly DataContext _context;

        public QuestionService(DataContext context)
        {
            _context = context;
        }

        public async Task<Question> CreateQuestion(Question question)
        {
            _context.Questions.Add(question);
            await _context.SaveChangesAsync();
            return question;
        }

        public async Task DeleteQuestion(int id)
        {
            var question = await _context.Questions.FindAsync(id);
            if (question is null)
            {
                return;
            }
            _context.Questions.Remove(question);
            await _context.SaveChangesAsync();
        }

        public async Task<PagedResponse<Question>> GetAllQuestions()
        {

            IEnumerable<Question> questions = [];

            questions = await _context.Questions.ToListAsync();

            if (questions is null || questions.Count() <= 0)
            {

                return new PagedResponse<Question>
                {
                    Data = [],
                    TotalCount = 0,
                    IsSuccess = questions is null ? false : true,
                    Message = "No Articles Found"
                };
            }

            return new PagedResponse<Question>
            {
                Data = questions,
                TotalCount = questions.Count(),
                IsSuccess = true,
                Message = string.Empty
            };

        }

        public async Task<Question> UpdateQuestion(int id, Question question)
        {
            var existingQuestion = await _context.Questions.FindAsync(id);
            if (existingQuestion is null)
            {
                return null;
            }
            existingQuestion.ArticleTitle = question.ArticleTitle;
            existingQuestion.QuestionText = question.QuestionText;
            existingQuestion.ArticleId = question.ArticleId;
            _context.Questions.Update(existingQuestion);
            await _context.SaveChangesAsync();
            return existingQuestion;
        }

        public async Task<Question> GetQuestionById(int id)
        {
            var question = await _context.Questions.FindAsync(id);
            return question;
        }

    }
}
