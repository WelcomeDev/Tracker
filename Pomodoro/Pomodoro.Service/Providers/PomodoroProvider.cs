using Pomodoro.Di;
using Pomodoro.Di.Provider;
using Pomodoro.Service.Controllers.Exceptions;

namespace Pomodoro.Service.Providers
{
    public class PomodoroProvider
    {
        private readonly IList<IPomodoro> _pomodors = new List<IPomodoro>();
        private readonly IPomodoroProvider _provider;
        private readonly IPomodoroMapper _mapper;

        public PomodoroProvider(IPomodoroProvider provider, IPomodoroMapper mapper)
        {
            _provider = provider;
            _mapper = mapper;
        }

        public IPomodoro Get(Guid id)
        {
            var cache = _pomodors.SingleOrDefault(p => p.Id == id);
            if (cache is not null)
                return cache;

            var pomodoroData = _provider.GetById(id);
            if (pomodoroData is null)
                throw new PomodoroNotFoundException();

            var pomodoro = _mapper.ToPomodoro(pomodoroData);
            _pomodors.Add(pomodoro);
            return pomodoro;
        }
    }
}
