using SingleServiceApp.Bll.Auth;
using SingleServiceApp.Controllers.Authorization;
using SingleServiceApp.Di.Auth;

namespace SingleServiceApp.Providers.Auth
{
    public class AuthContext
    {
        private readonly IAuthAsyncProvider _provider;
        private readonly string _username;

        public AuthContext(IAuthAsyncProvider provider, IHttpContextAccessor accessor)
        {
            var providerLoc = provider;
            try
            {
                _username = accessor.HttpContext.Request.Headers["Authorization"][0].Split(' ')[1];
                var user = providerLoc.GetUserByGuid(_username).Result;

                if (user is null)
                    throw new AuthorizationException();

                _provider = providerLoc;
            }
            catch (Exception)
            {
                accessor.HttpContext.Response.Redirect("/auth");
            }
        }

        public UserEntry GetCurrentUser()
        {
            if(_username is null) throw new AuthorizationException();

            var user = _provider.GetUserByGuid(_username).Result;
            return new UserEntry { Id = user.Id, Name = user.Login };
        }
    }
}
