using Pomodoro.Di;
using Pomodoro.Di.Provider;

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

        public IPomodoro? Get(Guid id)
        {
            var cache = _pomodors.SingleOrDefault(p => p.Id == id);
            if (cache is not null)
                return cache;

            return _mapper.ToPomodoro(_provider.GetById(id));
        }
    }
}
