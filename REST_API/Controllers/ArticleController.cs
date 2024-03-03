using Microsoft.AspNetCore.Mvc;
using REST_API.Models;
using REST_API.Services;

namespace REST_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticleController : ControllerBase
    {

        private readonly IArticleRepository _repository;

        public ArticleController(IArticleRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<List<Article>>> GetArticles()
        {
            return Ok(await _repository.GetAllArticles());
        }

       
        [HttpGet("{id}")]
        public async Task<ActionResult<Article>> GetArticle(int id)
        {
            var article = await _repository.GetArticleById(id);
            if (article == null)
            {
                return NotFound();
            }
            return Ok(article);
        }

         
        [HttpPost]
        public async Task<ActionResult<List<Article>>> CreateArticle(Article article)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
           await _repository.CreateArticle(article);

            return Ok(await _repository.GetAllArticles());
        }

        
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateArticle(int id, Article article)
        {
            if (id != article.ArticleId)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var update= await _repository.UpdateArticle(id, article);
            if ( update == null)
            {
                return NotFound();
            }
    
            return Ok(update);
        }

       
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteArticle(int id)
        {
            await _repository.DeleteArticle(id);

            return NoContent();
        }
    }
}
