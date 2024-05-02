using REST_API.Models;
using REST_API.Services;

namespace REST_API.Managers
{
    public class UserResultManager : IUserResultManager
    {
        private readonly IUserResultService _service;
         
        public UserResultManager(IUserResultService resultService)
        {
            _service = resultService;
        }
        public async Task<int> GetResult( int id)
        {
            return await _service.GetResult(id);
        }

        public async Task NextArticle(QuestionAnswerMap questionAnswerMap)
        {
            await _service.NextArticle(questionAnswerMap);
        }
    }
}
