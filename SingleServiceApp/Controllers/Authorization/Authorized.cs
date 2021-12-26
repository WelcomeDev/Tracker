using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace SingleServiceApp.Controllers.Authorization
{
    [AttributeUsage(AttributeTargets.Class)]
    public class AuthorizedAttribute : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            try
            {
                var key = context.HttpContext.Request.Headers["Authorization"][0].Split(' ')[1];
            }
            catch (Exception)
            {
                context.Result = new ForbidResult();
            }
        }
    }
}
