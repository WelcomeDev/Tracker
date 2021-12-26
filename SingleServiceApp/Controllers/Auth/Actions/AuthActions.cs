using Microsoft.IdentityModel.Tokens;
using Microsoft.Win32;

using SingleServiceApp.AppConfiguration;
using SingleServiceApp.Controllers.Auth.Dto;
using SingleServiceApp.Di.Auth;
using SingleServiceApp.Providers.Auth.Security;

using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace SingleServiceApp.Controllers.Auth.Actions
{
    public class AuthActions
    {
        private const int TokenHoursLifeTime = 24;
        private IAuthAsyncProvider _provider;

        public async Task<Token> SignIn(string username, string password)
        {
            var claimsIdentity = await GetIdentity(username, password);

            return new Token(CreateJwt(claimsIdentity.Claims));
        }

        private async Task<ClaimsIdentity> GetIdentity(string username, string password)
        {
            var user = await _provider.GetUser(username);
            if (user is null)
                return null;

            IEncryptionAlgorithm enc = new DesEncryption(username);

            if (!user.Password.Equals(enc.Decryption(password)))
                return null;

            return GetClaimsAdentity(user.Name);
        }

        public async Task<Token> SignUp(string username, string password)
        {
            IEncryptionAlgorithm enc = new DesEncryption(username);
            await _provider.CreateUser(username, enc.Encryption(password));
            return new Token(CreateJwt(GetClaimsAdentity(username).Claims));
        }

        private string CreateJwt(IEnumerable<Claim> claims)
        {
            var now = DateTime.UtcNow;
            var jwt = new JwtSecurityToken(
                issuer: AuthOptions.Issuer,
                audience: AuthOptions.Audience,
                notBefore: now,
                claims: claims,
                expires: now.Add(TimeSpan.FromHours(TokenHoursLifeTime)),
                signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256)
                );

            return new JwtSecurityTokenHandler().WriteToken(jwt);
        }

        private ClaimsIdentity GetClaimsAdentity(string username)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, username),
            };

            ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims,
                                                               "Token",
                                                               ClaimsIdentity.DefaultNameClaimType,
                                                               ClaimsIdentity.DefaultRoleClaimType);

            return claimsIdentity;
        }
    }
}
