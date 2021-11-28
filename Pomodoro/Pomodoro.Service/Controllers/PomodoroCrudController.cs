
using Microsoft.AspNetCore.Mvc;

using Pomodoro.Di;
using Pomodoro.Di.Provider;
using Pomodoro.Service.Controllers.Actions;
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
        private readonly IPomodoroProvider _provider;
        private readonly IEnumerable<IPomodoroValidation> _validations;

        public PomodoroCrudController(IPomodoroProvider provider, IEnumerable<IPomodoroValidation> validations)
        {
            _provider = provider;
            _validations = validations;
        }

        [HttpGet]
        public PageableList<IPomodoroData> GetAll([FromQuery] PageableParams pageable)
        {
            var value = _provider.GetAll(pageable);
            return value;
        }

        [HttpGet]
        [Route("{id:guid}")]
        public IPomodoroData GetByID([FromRoute] Guid id)
        {
            //todo: validation here?
            return _provider.GetById(id);
        }

        [HttpPost]
        [Route("{id:guid}/delete")]
        public void Delete([FromRoute] Guid id)
        {
            //todo: validation here?
            _provider.Delete(id);
        }

        [HttpPost]
        [Route("create")]
        [ProducesResponseType(Status201Created)]

        public IPomodoroData Create([FromBody] PomodoroCreationDto pomodoroData)
        {
            _validations.ForEach(x => x.Validate(pomodoroData));
            return _provider.Create(pomodoroData);
        }

        [HttpPost]
        [Route("{id:guid}/update")]
        public IPomodoroData Update([FromRoute] Guid id, [FromBody] PomodoroCreationDto pomodoroData)
        {
            _validations.ForEach(x => x.Validate(pomodoroData));
            return _provider.Update(id, pomodoroData);
        }
    }
}
