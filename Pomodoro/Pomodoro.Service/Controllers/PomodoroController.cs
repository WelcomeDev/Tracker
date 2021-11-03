using Microsoft.AspNetCore.Mvc;
using Pomodoro.Di;
using Pomodoro.Di.Provider;
using Pomodoro.Service.Controllers.Dto;

namespace Pomodoro.Service.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PomodoroController : ControllerBase
    {
        private readonly IPomodoroProvider _provider;

        public PomodoroController(IPomodoroProvider provider)
        {
            _provider = provider;
        }

        [HttpGet(Name = "GetAll")]
        public IEnumerable<IPomodoroData> GetAll()
        {
            return _provider.GetAll();
        }

        //[HttpGet(Name = "GetPomodoro")]
        //public IPomodoroData GetByID(Guid guid)
        //{
        //    return _provider.GetById(guid);
        //}

        //[HttpPost(Name = "PostPomodoroDelete")]
        //public void Delete(Guid guid)
        //{
        //    _provider.Delete(guid);
        //}

        //[HttpPost(Name = "PostPomodoroCreate")]
        //public IPomodoroData Create(PomodoroCreationDto pomodoroData)
        //{
        //    return _provider.Create(pomodoroData);
        //}

        //[HttpPost(Name = "PostPomodoroUpdate")]
        //public IPomodoroData Update(IPomodoroData pomodoroData)
        //{
        //    return _provider.Update(pomodoroData);
        //}
    }
}
