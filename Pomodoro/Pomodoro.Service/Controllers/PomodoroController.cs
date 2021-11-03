using Microsoft.AspNetCore.Mvc;
using Pomodoro.Di;
using Pomodoro.Di.Provider;

namespace Pomodoro.Service.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PomodoroController : ControllerBase
    {
        private readonly IPomodoroProvider _provider;

        public PomodoroController(IPomodoroProvider provider)
        {
            _provider = provider;
        }

        [HttpGet(Name = "GetAllPomodoros")]
        public IEnumerable<IPomodoroData> GetAll()
        {
            return _provider.GetAll();
        }

        [HttpGet(Name = "GetPomodoroByID")]
        public IPomodoroData GetByID(Guid guid)
        {
            return _provider.GetById(guid);
        }

        [HttpPost(Name = "DeletePomodoro")]
        public void Delete(Guid guid)
        {
            _provider.Delete(guid);
        }

        [HttpPost(Name = "CreatePomodoro")]
        public IPomodoroData Create(IPomodoroData pomodoroData)
        {
            _provider.Create(pomodoroData);
            return _provider.GetById(pomodoroData.Id);
        }

        [HttpPost(Name = "UpdatePomodoro")]
        public IPomodoroData Update(IPomodoroData pomodoroData)
        {
            _provider.Update(pomodoroData);
            return _provider.GetById(pomodoroData.Id);
        }
    }
}
