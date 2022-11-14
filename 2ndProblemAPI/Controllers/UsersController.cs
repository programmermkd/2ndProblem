using _2ndProblemAPI.Objects.Requests.Users;
using _2ndProblemApp;
using _2ndProblemApp.Contracts;
using _2ndProblemApp.Object;
using Microsoft.AspNetCore.Mvc;

namespace _2ndProblemAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("GetById")]
        public async Task<ActionResult<UserWithValidIdDTO>> GetByIdAsync(GetUserById request)
        {
            var user = await _userService.GetUserAsync(request.Id);

            if (user == null)
            {
                return NotFound($"User with id {request.Id} not found");
            }

            return Ok(user);
        }

        [HttpPost("GetUsersWithValidId")]
        public async Task<ActionResult<UserWithValidIdDTO>> GetAllAsync()
        {
            var users = await _userService.GetUsersWithValidIdAsync();

            return Ok(users);
        }

        [HttpPost("GetUsersWithGroup")]
        public async Task<ActionResult<UserWithValidIdDTO>> GetUserByIdWithGroupAsync(GetUserById request)
        {
            var user = await _userService.GetUserByIdWithGroupAsync(request.Id);

            if (user == null)
            {
                return NotFound($"User with id {request.Id} not found");
            }

            return Ok(user);
        }

    }
}