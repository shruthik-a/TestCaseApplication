using Microsoft.AspNetCore.Mvc;
using TestCaseApplication.Model;

namespace TestCaseApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IService _service;

        public UserController(IService service)
        {
            _service = service;
        }
        [HttpGet]
        public async Task<List<User>> GetAllUsers()
        {
            return await _service.GetAllUsers();
        }

        [HttpPost]
        public async Task<IActionResult> AddUser([FromBody] User user)
        {
            User newUser = new User
            {
                Username = user.Username,
                Password = user.Password
            };

            await _service.AddUser(newUser);

            return CreatedAtAction(nameof(GetAllUsers), new { id = newUser.Id }, newUser);
        }
    }
}
