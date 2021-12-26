using Microsoft.AspNetCore.Mvc;
using SingleServiceApp.Controllers.Auth.Dto;
using SingleServiceApp.Controllers.Auth.Actions;
using SingleServiceApp.Providers.Auth;

namespace SingleServiceApp.Controllers.Auth
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController : ControllerBase
    {
        private readonly AuthActions _authActions;
        private readonly AuthContext _authContext;

        public AuthController(AuthActions authActions, AuthContext authContext)
        {
            _authActions = authActions;
            _authContext = authContext;
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] AuthDto auth)
        {
            if (auth == null)
                return BadRequest();

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

        [HttpPost]
        [Route("whoami")]
        public async Task<IActionResult> WhoAmI()
        {
            if(_authContext.GetCurrentUser() is null)
                return Unauthorized();

            return Ok(_authContext.GetCurrentUser());
        }
    }
}
