using Microsoft.AspNetCore.Mvc;
using REST_API.Managers;
using REST_API.Models;
using REST_API.Services;

namespace REST_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticleController : ControllerBase
    {

        private readonly IArticleManager _articleManager;

        public ArticleController(IArticleManager articleManager)
        {
            _articleManager = articleManager;
        }

        [HttpGet]
        public async Task<ActionResult<List<Article>>> GetArticles()
        {
            return Ok(await _articleManager.GetAllArticles());
        }


        [HttpGet("{id}")]
         
        public async Task<ActionResult<Article>> GetArticle(int id)
        {
             
            return Ok(await _articleManager.GetArticleById(id));
        }


        [HttpPost]
        [Route("CreateArticle")]
        public async Task<ActionResult<Article>> CreateArticle(Article article)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(await _articleManager.CreateArticle(article));
        }


        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateArticle(int id, Article article)
        {
             
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(await _articleManager.UpdateArticle(id, article));
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteArticle(int id)
        {
            await _articleManager.DeleteArticle(id);

            return NoContent();
        }
    }
}
