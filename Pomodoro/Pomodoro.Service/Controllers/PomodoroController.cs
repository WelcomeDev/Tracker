using Microsoft.AspNetCore.Mvc;

using Pomodoro.Di.Duration;
using Pomodoro.Service.Providers;

namespace Pomodoro.Service.Controllers
{
    [ApiController]
    [Route("api/pomodoro")]
    public class PomodoroController : ControllerBase
    {
        private readonly PomodoroProvider _provider;

        public PomodoroController(PomodoroProvider provider)
        {
            _provider = provider;
        }

        [HttpGet]
        [Route("{id:guid}/status")]
        public IDuration Status([FromRoute] Guid id)
        {
            return _provider.Get(id).Status();
        }

        [HttpPost]
        [Route("{id:guid}/start")]
        public void Start([FromRoute] Guid id)
        {
            //dcfc30f2-6049-4b73-b466-53899bffd593
            _provider.Get(id).Start();
        }

        [HttpPost]
        [Route("{id:guid}/cancel")]
        public void Cancel([FromRoute] Guid id)
        {
            _provider.Get(id).Cancel();
        }

        [HttpPost]
        [Route("{id:guid}/pause")]
        public void Pause([FromRoute] Guid id)
        {
            _provider.Get(id).Pause();
        }

        [HttpPost]
        [Route("{id:guid}/resume")]
        public void Resume([FromRoute] Guid id)
        {
            _provider.Get(id).Resume();
        }
    }
}
