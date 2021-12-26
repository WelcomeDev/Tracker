using SingleServiceApp.Bll.Auth;
using SingleServiceApp.Controllers.Authorization;
using SingleServiceApp.Di.Auth;

namespace SingleServiceApp.Providers.Auth
{
    public class AuthContext
    {
        private readonly IAuthAsyncProvider _provider;
        private string _username;
        private readonly IHttpContextAccessor _accessor;

        public AuthContext(IAuthAsyncProvider provider, IHttpContextAccessor accessor)
        {
            _provider = provider;
            _accessor = accessor;
            
            try
            {
                _username = GetId();
                var user = provider.GetUserByGuid(_username).Result;

                if (user is null)
                    throw new AuthorizationException();
            }
            catch (Exception)
            {
                accessor.HttpContext.Response.Redirect("/auth");
            }
        }

        private string GetId()
        {
            try
            {
                return _accessor.HttpContext.Request.Headers["Authorization"][0].Split(' ')[1];
            }
            catch (Exception)
            {
                return null;
            }
        }

        public UserEntry GetCurrentUser()
        {
            if (_username is null)
                _username = GetId();

            if (_username is null) throw new AuthorizationException();

            var user = _provider.GetUserByGuid(_username).Result;
            return new UserEntry { Id = user.Id, Name = user.Login };
        }
    }
}
