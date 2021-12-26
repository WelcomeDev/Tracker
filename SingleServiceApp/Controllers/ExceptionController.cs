using System.Net;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

using SingleServiceApp.Controllers.Auth.Exceptions;
using SingleServiceApp.Controllers.Authorization;
using SingleServiceApp.Controllers.Pomodoro.Exceptions;

namespace SingleServiceApp.Controllers
{
    [AllowAnonymous]
    [ApiExplorerSettings(IgnoreApi = true)]
    public class ExceptionController : ControllerBase
    {
        [Route("/error")]
        public ErrorDto Error()
        {
            var exception = HttpContext.Features.Get<IExceptionHandlerFeature>().Error;
            int statusCode = (int)GetStatusCode(exception);
            HttpContext.Response.StatusCode = statusCode;

            return new ErrorDto(statusCode, exception.Message);
        }

        private HttpStatusCode GetStatusCode(Exception exception) =>
            exception switch
            {
                PomodoroNotFoundException => HttpStatusCode.BadRequest,
                PomodoroValidationException => HttpStatusCode.BadRequest,
                InvalidLoginOrPasswordException => HttpStatusCode.BadRequest,
                AuthorizationException => HttpStatusCode.Unauthorized,
                _ => HttpStatusCode.InternalServerError,
            };
    }
}
