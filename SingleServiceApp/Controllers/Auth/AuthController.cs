using Microsoft.AspNetCore.Mvc;
using SingleServiceApp.Controllers.Auth.Dto;
using SingleServiceApp.Di.Auth;
using SingleServiceApp.Controllers.Auth.Actions;

namespace SingleServiceApp.Controllers.Auth
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController : ControllerBase
    {
        private readonly AuthActions _authActions;

        public AuthController(AuthActions authActions)
        {
            _authActions = authActions;
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] AuthDto auth)
        {
            var token = await _authActions.SignIn(auth.Username, auth.Password);

            return Ok(token);
        }

        [HttpPost]
        [Route("sign-up")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> SignUp([FromBody] RegisterDto register)
        {
            var token = await _authActions.SignUp(register.Username, register.Password);

            return Ok(token);
        }
    }
}
