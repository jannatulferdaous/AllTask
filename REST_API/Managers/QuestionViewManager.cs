using REST_API.Models;
using REST_API.Services;

namespace REST_API.Managers
{
    public class QuestionViewManager : IQuestionViewManager
    {
        private readonly IQsnViewService _service;
        public QuestionViewManager(IQsnViewService service)
        {
            _service = service;
        }
       public async Task<List<QuestionViewPage>> Index(int id)
        {
            return await _service.Index(id);
        }
       
         

        public async Task SaveAnswers(List<QuestionAnswerMap> questionViewPages)
        {
            await _service.SaveAnswers(questionViewPages);
        }
    }
}
