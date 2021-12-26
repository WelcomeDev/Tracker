using SingleServiceApp.Bll.Auth;
using SingleServiceApp.Di.Auth;

using System.Security.Claims;

namespace SingleServiceApp.Providers.Auth
{
    public class AuthProvider
    {
        private readonly IAuthAsyncProvider _provider;
        private readonly string _username;

        public AuthProvider(IAuthAsyncProvider provider, ClaimsPrincipal claimsPrincipal)
        {
            _provider = provider;
            _username = claimsPrincipal.Identity.Name;
        }

        public UserEntry GetCurrentUser()
        {
            var user = _provider.GetUser(_username).Result;
            return new UserEntry { Id = user.Id, Name = user.Name };
        }
    }
}
