
using AutoMapper;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using SingleServiceApp.Controllers.Pomodoro.Dto;
using SingleServiceApp.Controllers.Pomodoro.Validation;
using SingleServiceApp.Di.Pomodoros;

using WelcomeDev.Provider.Di.Pageable;
using WelcomeDev.Utils.Enumerable;

using static Microsoft.AspNetCore.Http.StatusCodes;

namespace SingleServiceApp.Controllers.Pomodoro
{
    [ApiController]
    [Route("api/pomodoro")]
    [Authorize]
    public class PomodoroCrudController : ControllerBase
    {
        private readonly IPomodoroAsyncProvider _provider;
        private readonly IEnumerable<IPomodoroValidation> _validations;
        private readonly IMapper _mapper;

        public PomodoroCrudController(IPomodoroAsyncProvider provider, IEnumerable<IPomodoroValidation> validations, IMapper mapper)
        {
            _provider = provider;
            _validations = validations;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] PageableParams pageable)
        {
            var value = await _provider.GetAll();

            return Ok(new PageableList<PomodoroDto>(
                value.Select(x => _mapper.Map<PomodoroDto>(x)), 
                pageable));
        }

        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> GetByID([FromRoute] Guid id)
        {
            var pomodoro = await _provider.GetById(id);
            return Ok(_mapper.Map<PomodoroDto>(pomodoro));
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
        public async Task<IActionResult> Create([FromBody] CreatePomodoroDto pomodoroData)
        {
            var validationParams = _mapper.Map<ValidationParams>(pomodoroData);
            _validations.ForEach(x => x.Validate(validationParams));
            var pomodoro = await _provider.Create(pomodoroData);

            return Ok(_mapper.Map<PomodoroDto>(pomodoro));
        }

        [HttpPost]
        [Route("{id:guid}/update")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdatePomodoroDto pomodoroData)
        {
            var validationParams = _mapper.Map<ValidationParams>(pomodoroData);
            _validations.ForEach(x => x.Validate(validationParams));

            var pomodoro = await _provider.Update(id, pomodoroData);

            return Ok(_mapper.Map<PomodoroDto>(pomodoro));
        }
    }
}
