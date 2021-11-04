using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Pomodoro.Di;
using Pomodoro.Di.Provider;

namespace Pomodoro.Service.Controllers
{
    [ApiController]
    [Route("api/pomodoro")]
    public class PomodoroController : ControllerBase
    {
        private readonly IPomodoroProvider _provider;
        private readonly IPomodoroMapper _mapper;

        public PomodoroController(IPomodoroProvider provider, IPomodoroMapper mapper)
        {
            _provider = provider;
            _mapper = mapper;
        }

        [HttpPost]
        [Route("{id:guid}/start")]
        public void Start([FromRoute] Guid id)
        {

        }

        [HttpPost]
        [Route("{id:guid}/cancel")]
        public void Cancel([FromRoute] Guid id)
        {

        }

        [HttpPost]
        [Route("{id:guid}/pause")]
        public void Pause([FromRoute] Guid id)
        {

        }

        [HttpPost]
        [Route("{id:guid}/resume")]
        public void Resume([FromRoute] Guid id)
        {

        }
    }
}
