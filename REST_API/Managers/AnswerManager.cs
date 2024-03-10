using REST_API.Models;
using REST_API.Response;
using REST_API.Services;

namespace REST_API.Managers
{
    public class AnswerManager : IAnswerManager
    {
        private readonly IAnswerService _service;
        public AnswerManager (IAnswerService service) 
        {
            _service = service;
        }
        public  async Task<QAnswer> CreateAnswer(QAnswer answer)
        {
             return await _service.CreateAnswer(answer);
        }

        public async Task DeleteAnswer(int id)
        {
            await _service.DeleteAnswer(id);
        }

        public async Task<PagedResponse<QAnswer>> GetAllAnswers()
        {
            return await _service.GetAllAnswers();
        }

        public async Task<QAnswer> GetAnswerById(int id)
        {
             return await _service.GetAnswerById(id); 
        }

        public async Task<QAnswer> UpdateAnswer(int id, QAnswer answer)
        {
            return await _service.UpdateAnswer(id, answer);
        }
    }
}
