using System.Net;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

using SingleServiceApp.Controllers.Pomodoro.Dto;
using SingleServiceApp.Controllers.Pomodoro.Exceptions;

namespace SingleServiceApp.Controllers
{
    [AllowAnonymous]
    [ApiExplorerSettings(IgnoreApi = true)]
    public class ExceptionController : ControllerBase
    {
        [Route("/error")]
        public ExceptionDto Error()
        {
            var exception = HttpContext.Features.Get<IExceptionHandlerFeature>().Error;
            int statusCode = (int)GetStatusCode(exception);

            return new ExceptionDto(statusCode, exception.Message);
        }

        private HttpStatusCode GetStatusCode(Exception exception) =>
            exception switch
            {
                PomodoroNotFoundException => HttpStatusCode.BadRequest,
                PomodoroValidationException => HttpStatusCode.BadRequest,
                _ => HttpStatusCode.InternalServerError,
            };
    }
}
