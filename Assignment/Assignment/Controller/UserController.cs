using Assignment.Model.Domain;
using Assignment.Model.RequestDto;
using Assignment.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Assignment.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> GetUsers([FromQuery] UserListDto model)
        {
            var res = await _userService.GetAllAsync(model);
            return Ok(res);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser(int id)
        {
            var res = await _userService.GetByIdAsync(id);
            return StatusCode((int)res.StatusCode, res);
        }

        [HttpPost]
        public async Task<IActionResult> AddUser(User user)
        {
            var res = await _userService.AddAsync(user);
            return StatusCode((int)res.StatusCode, res);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(int id, User user)
        {
            var res = await _userService.UpdateAsync(id, user);
            return StatusCode((int)res.StatusCode, res);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var res = await _userService.DeleteAsync(id);
            return StatusCode((int)res.StatusCode, res);
        }
    }
}
