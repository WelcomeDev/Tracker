
using Microsoft.AspNetCore.Mvc;

using Pomodoro.Di;
using Pomodoro.Di.Provider;
using Pomodoro.Service.Controllers.Actions.Validation;
using Pomodoro.Service.Controllers.Dto;

using WelcomeDev.Provider.Di.Pageable;
using WelcomeDev.Utils.Enumerable;

using static Microsoft.AspNetCore.Http.StatusCodes;

namespace Pomodoro.Service.Controllers
{
    [ApiController]
    [Route("api/pomodoro")]
    public class PomodoroCrudController : ControllerBase
    {
        private readonly IPomodoroAsyncProvider _provider;
        private readonly IEnumerable<IPomodoroValidation> _validations;
        
        public PomodoroCrudController(IPomodoroAsyncProvider provider, IEnumerable<IPomodoroValidation> validations)
        {
            _provider = provider;
            _validations = validations;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] PageableParams pageable)
        {
            var value = await _provider.GetAll(pageable);

            return Ok(value);
        }

        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IPomodoroData> GetByID([FromRoute] Guid id)
        {
            return await _provider.GetById(id);
        }

        [HttpPost]
        [Route("{id:guid}/delete")]
        public void Delete([FromRoute] Guid id)
        {
            _provider.Delete(id);
        }

        [HttpPost]
        [Route("create")]
        [ProducesResponseType(Status201Created)]
        public async Task<IActionResult> Create([FromBody] PomodoroCreationDto pomodoroData)
        {
            _validations.ForEach(x => x.Validate(pomodoroData));
            var pomodoro = await _provider.Create(pomodoroData);

            return Ok(pomodoro);
        }

        [HttpPost]
        [Route("{id:guid}/update")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] PomodoroCreationDto pomodoroData)
        {
            _validations.ForEach(x => x.Validate(pomodoroData));
            var pomodoro = await _provider.Update(id, pomodoroData);
            return Ok(pomodoro);
        }
    }
}
