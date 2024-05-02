using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using REST_API.Managers;
using REST_API.Models;

namespace REST_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserResultController : ControllerBase
    {
        private readonly IUserResultManager _userResultManager;
        public UserResultController(IUserResultManager userResult ) 
        { 
            _userResultManager = userResult;
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetResult(int id)
        {
            return Ok(await _userResultManager.GetResult(id));
        }
        [HttpPost]
        //[Route("NextArticle")]
        public async Task<ActionResult> NextArticle (QuestionAnswerMap questionAnswerMap)
        {
            await _userResultManager.NextArticle(questionAnswerMap);
            return Ok();
        }
    }
}
