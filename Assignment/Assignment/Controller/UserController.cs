using Assignment.Model.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Assignment.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetUsers() => Ok();

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser(int id)
        {
          return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> AddUser(User user)
        {
            return BadRequest("Only JSON data source supports adding users.");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(int id, User user)
        {
            return BadRequest("Only JSON data source supports updating users.");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            return BadRequest("Only JSON data source supports deleting users.");
        }
    }
}
