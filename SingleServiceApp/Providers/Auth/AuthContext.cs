using SingleServiceApp.Bll.Auth;
using SingleServiceApp.Di.Auth;

using System.Security.Claims;

namespace SingleServiceApp.Providers.Auth
{
    public class AuthContext
    {
        private readonly IAuthAsyncProvider _provider;
        private readonly string _username;
        private User _user;

        public AuthContext(IHttpContextAccessor httpContextAccessor, IAuthAsyncProvider provider)
        {
            _username = httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;

            _provider = provider;
        }

        public UserEntry GetUser()
        {
            if (_user is null)
            {
                var user = _provider.GetUser(_username).Result;
                _user = user;
            }

            return new UserEntry
            {
                Id = _user.Id,
                Name = _user.Name,
            };
        }
    }
}
