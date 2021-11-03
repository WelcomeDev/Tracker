using Microsoft.AspNetCore.Mvc;

using Pomodoro.Di.Provider;

namespace Pomodoro.Service.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PomodoroController: ControllerBase
    {
        private readonly IPomodoroProvider _provider;

        public PomodoroController(IPomodoroProvider provider)
        {
            _provider = provider;
        }
    }
}
