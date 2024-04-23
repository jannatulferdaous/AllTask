 using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using REST_API.DataLayer;
using REST_API.Managers;
using REST_API.Models;

namespace REST_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionsController : ControllerBase
    {
        private readonly IQuestionManager _questionManager;

        public QuestionsController(IQuestionManager questionManager)
        {
            _questionManager = questionManager;
        }

        [HttpGet]
        public async Task<ActionResult<List<Question>>> GetQuestions()
        {
            return Ok(await _questionManager.GetAllQuestions());
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Question>> GetQuestion(int id)
        {

            return Ok(await _questionManager.GetQuestionById(id));
        }


        [HttpPost]
        [Route("CreateQuestion")]
        public async Task<ActionResult<Question>> CreateQuestion(Question question)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(await _questionManager.CreateQuestion(question));
        }


        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateQuestion(int id, Question question)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(await _questionManager.UpdateQuestion(id, question));
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteQuestion(int id)
        {
            await _questionManager.DeleteQuestion(id);

            return NoContent();
        }
         
    }
}
