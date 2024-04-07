using Microsoft.AspNetCore.Mvc;
using REST_API.Managers;
using REST_API.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace REST_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserManager _userManager;
        public UserController (IUserManager userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<ActionResult<List<User>>> GetAllUsers()
        {
            return Ok(await _userManager.GetAllUsers());
        }

        
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            return Ok(await _userManager.GetUserById(id));
        }


        [HttpPost]
        [Route("CreateUser")]
        public async Task<ActionResult<User>> CreateUser(User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(await _userManager.CreateUser(user));
        }

        [HttpPost]
        [Route("ValidUser")]
        public async Task<ActionResult<User>> ValidUser(Login login)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(await _userManager.ValidUser(login));
        }


        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateUser(int id, User user)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(await _userManager.UpdateUser(id, user));
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            await _userManager.DeleteUser(id);

            return NoContent();
        }
    }
}
