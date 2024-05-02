using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using REST_API.Managers;
using REST_API.Models;

namespace REST_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionViewController : ControllerBase
    {
        private readonly IQuestionViewManager _questionViewManager;

        public QuestionViewController(IQuestionViewManager questionManager)
        {
            _questionViewManager = questionManager;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<QuestionViewPage>>>Index(int id)
        {
            return Ok(await _questionViewManager.Index(id));
        }


        [HttpPost]
        [Route("Index")]
        public async Task<ActionResult>Index(List<QuestionAnswerMap> questionViewPages)
        {
            await _questionViewManager.SaveAnswers(questionViewPages);
            return Ok();
        }
    }
}
