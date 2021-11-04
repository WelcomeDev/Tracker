using System.Runtime.InteropServices;

using Microsoft.AspNetCore.Mvc;
using static Microsoft.AspNetCore.Http.StatusCodes;
using Pomodoro.Di.Provider;
using Pomodoro.Service.Controllers.Dto;
using Pomodoro.Di;

namespace Pomodoro.Service.Controllers
{
    [ApiController]
    [Route("api/pomodoro")]
    public class PomodoroCrudController : ControllerBase
    {
        private readonly IPomodoroProvider _provider;

        public PomodoroCrudController(IPomodoroProvider provider)
        {
            _provider = provider;
        }

        [HttpGet]
        public IEnumerable<IPomodoroData> GetAll()
        {
            return _provider.GetAll();
        }

        [HttpGet]
        [Route("{id:guid}")]
        public IPomodoroData GetByID([FromRoute] Guid id)
        {
            return _provider.GetById(id);
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
        public IPomodoroData Create(PomodoroCreationDto pomodoroData)
        {
            return _provider.Create(pomodoroData);
        }

        [HttpPost]
        [Route("{id:guid}/update")]
        public IPomodoroData Update(IPomodoroData pomodoroData)
        {
            return _provider.Update(pomodoroData);
        }
    }
}
