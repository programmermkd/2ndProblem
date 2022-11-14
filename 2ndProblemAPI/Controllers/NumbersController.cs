using _2ndProblemAPI.Objects.Requests.Users;
using _2ndProblemApp;
using _2ndProblemApp.Contracts;
using _2ndProblemApp.Object;
using Microsoft.AspNetCore.Mvc;

namespace _2ndProblemAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NumbersController : ControllerBase
    {
        private readonly INumbersService _numberService;

        public NumbersController(INumbersService numberService)
        {
            _numberService = numberService;
        }

        [HttpPost("CheckIfDiagonalSumsAreEqual")]
        public async Task<ActionResult<bool>> CheckIfDiagonalSumsAreEqual()
        {
            return Ok(await _numberService.AreDiagonalsEqualAsync());
        }
    }
}