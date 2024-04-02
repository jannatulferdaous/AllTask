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
    public class QAnswersController : ControllerBase
    {
        private readonly IAnswerManager _answerManager;

        public QAnswersController(IAnswerManager answerManager)
        {
            _answerManager = answerManager;
        }

        
        [HttpGet]
        public async Task<ActionResult<List<QAnswer>>> GetAnswers()
        {
            return Ok( await _answerManager.GetAllAnswers());
        }

        
        [HttpGet("{id}")]
        public async Task<ActionResult<QAnswer>> GetAnswer(int id)
        {
            return Ok(await _answerManager.GetAnswerById(id));
        }

         
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAnswer(int id, QAnswer qAnswer)
        {
            if (id != qAnswer.Id)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(await _answerManager.UpdateAnswer(id, qAnswer));

        }

         
        [HttpPost]
        [Route("CreateAnswer")]
        public async Task<ActionResult<QAnswer>> CreateAnswer(QAnswer qAnswer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(await _answerManager.CreateAnswer(qAnswer));
             
        }

         
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAnswer(int id)
        {
            await _answerManager.DeleteAnswer(id);

            return NoContent();
        }

         
    }
}
