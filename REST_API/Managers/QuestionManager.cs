using REST_API.Models;
using REST_API.Response;
using REST_API.Services;

namespace REST_API.Managers
{
    public class QuestionManager : IQuestionManager
    {

         
        private readonly IQuestionService _questionService;

        
        public QuestionManager(IQuestionService questionService)
        {
            _questionService = questionService;
        }
        public async Task<Question> CreateQuestion(Question question)
        {
            return await _questionService.CreateQuestion(question);
        }

        public async Task DeleteQuestion(int id)
        {
            await _questionService.DeleteQuestion(id);
        }

        public  async Task<PagedResponse<Question>> GetAllQuestions()
        {
            return await _questionService.GetAllQuestions();
        }

        public async Task<Question> GetQuestionById(int id)
        {
            return await _questionService.GetQuestionById(id);
        }

        public async Task<Question> UpdateQuestion(int id, Question question)
        {
            return await _questionService.UpdateQuestion(id, question);
        }
    }
}
