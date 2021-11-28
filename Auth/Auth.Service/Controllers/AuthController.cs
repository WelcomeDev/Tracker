using Auth.Service.Controllers.Dto;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

using System.IdentityModel.Tokens.Jwt;

namespace Auth.Service.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController:ControllerBase
    {
        private readonly IConfiguration _configuration;

        public AuthController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpPost]
        [Route("auth")]
        public async Task<IActionResult> Auth([FromBody] SecretDto secret, [FromBody] AuthDto auth)
        {
            string token = _configuration["JWT:Token"];

            var token = new JwtSecurityToken(
                
                );

            return Ok();
        }
    }
}
