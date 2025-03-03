using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UserAuth.Core.Dtos;
using UserAuth.Core.ServicesContract;

namespace UserAuth.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;

        public AuthController(IUserService userService)
        {
            _userService = userService;
        }


        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterDto registerDto)
        {
            var user  = await _userService.Register(registerDto);

            if (user == null )
            {
                return Unauthorized();
            }

            return Ok(user);
        }

        [HttpPost("login")]

        public async Task<IActionResult> Login(LoginDto loginDto)
        {
            var user = await _userService.Login(loginDto);

            if (user == null )
            {
                return Unauthorized();
            }
            return Ok(user);
        }
    }
}
