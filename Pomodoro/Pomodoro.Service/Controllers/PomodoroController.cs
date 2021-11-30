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
        public async Task<IDuration> Status([FromRoute] Guid id)
        {
            var pomodoro = await _provider.Get(id);

            return pomodoro.Status();
        }

        [HttpPost]
        [Route("{id:guid}/start")]
        public async void Start([FromRoute] Guid id)
        {
            //dcfc30f2-6049-4b73-b466-53899bffd593
            var pomodoro = await _provider.Get(id);
            pomodoro.Start();
        }

        [HttpPost]
        [Route("{id:guid}/cancel")]
        public async void Cancel([FromRoute] Guid id)
        {
            var pomodoro = await _provider.Get(id);
            pomodoro.Cancel();
        }

        [HttpPost]
        [Route("{id:guid}/pause")]
        public async void Pause([FromRoute] Guid id)
        {
            //TODO: return IDuration

            //todo: should return duration?
            var pomodoro = await _provider.Get(id);
            pomodoro.Pause();
        }

        [HttpPost]
        [Route("{id:guid}/resume")]
        public async void Resume([FromRoute] Guid id)
        {
            var pomodoro = await _provider.Get(id);
            pomodoro.Resume();
            //TODO: return IDuration
        }
    }
}
