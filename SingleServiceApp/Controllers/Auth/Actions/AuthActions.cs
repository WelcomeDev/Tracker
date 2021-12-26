using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Win32;

using SingleServiceApp.AppConfiguration;
using SingleServiceApp.Bll.Auth;
using SingleServiceApp.Controllers.Auth.Dto;
using SingleServiceApp.Di.Auth;
using SingleServiceApp.Providers.Auth.Security;

using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace SingleServiceApp.Controllers.Auth.Actions
{
    public class AuthActions
    {
        private IAuthAsyncProvider _provider;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AuthActions(IAuthAsyncProvider provider, IHttpContextAccessor httpContextAccessor)
        {
            _provider = provider;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<Token> SignIn(string username, string password)
        {
            var claimsIdentity = await GetIdentity(username, password);

            if (claimsIdentity is null)
                throw new Exception("Invalid login or password");

            return new Token(claimsIdentity.Id.ToString());
        }

        private async Task<User> GetIdentity(string username, string password)
        {
            var user = await _provider.GetUser(username);
            if (user is null)
                return null;

            IEncryptionAlgorithm enc = new DesEncryption(username);

            if (!user.Password.Equals(enc.Encryption(password)))
                return null;

            return user;
        }

        public async Task<Token> SignUp(string username, string password)
        {
            IEncryptionAlgorithm enc = new DesEncryption(username);
            var user = await _provider.CreateUser(username, enc.Encryption(password));
            return new Token(user.Id.ToString());
        }

        private string CreateJwt(IEnumerable<Claim> claims)
        {
            var now = DateTime.UtcNow;
            var jwt = new JwtSecurityToken(
                issuer: AuthOptions.Issuer,
                audience: AuthOptions.Audience,
                notBefore: now,
                claims: claims,
                expires: now.Add(TimeSpan.FromHours(AuthOptions.TokenHoursLifeTime)),
                signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256)
                );

            return new JwtSecurityTokenHandler().WriteToken(jwt);
        }

        private ClaimsIdentity GetClaimsAdentity(User user)
        {
            var claims = new List<Claim>
            {
                new Claim("Login", user.Login),
                //new Claim("Role",user.Role),
                new Claim("Id", user.Id.ToString()),
            };

            ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims,
                                                               "Token");

            _httpContextAccessor.HttpContext.User = new ClaimsPrincipal(claimsIdentity);

            return claimsIdentity;
        }
    }
}
