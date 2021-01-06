using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Planner.BLL.Interfaces;
using Planner.Shared.Models;

namespace Planner.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("Register")]
        [ProducesResponseType(200, Type = typeof(UserManagerResponse))]
        [ProducesResponseType(400, Type = typeof(UserManagerResponse))]
        public async Task<IActionResult> RegisterAsync([FromBody] RegisterRequest model)
        {
            if (ModelState.IsValid)
            {
                var result = await _authService.RegisterUserAsync(model);

                if (result.Success)
                {
                    return Ok(result);
                }
                
                return BadRequest(result);
            }

            return BadRequest(new UserManagerResponse("Некоторые поля были введены неверно", false));
        }

        [HttpPost("Login")]
        [ProducesResponseType(200, Type = typeof(UserManagerResponse))]
        [ProducesResponseType(400, Type = typeof(UserManagerResponse))]
        public async Task<IActionResult> LoginAsync([FromBody] LoginRequest model)
        {
            if (ModelState.IsValid)
            {
                var result = await _authService.LoginUserAsync(model);

                if (result.Success)
                {
                    return Ok(result);
                }
                
                return BadRequest(result);
            }

            return BadRequest(new UserManagerResponse("Некоторые поля были введены неверно", false));
        }
    }
}
