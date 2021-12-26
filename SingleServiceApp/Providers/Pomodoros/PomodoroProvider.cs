using SingleServiceApp.Bll.Pomodoros;
using SingleServiceApp.Controllers.Pomodoro.Exceptions;
using SingleServiceApp.Di.Pomodoros;

namespace SingleServiceApp.Providers.Pomodoros
{
    public class PomodoroProvider
    {
        private readonly IList<Pomodoro> _pomodors = new List<Pomodoro>();
        private readonly IPomodoroAsyncProvider _provider;

        public PomodoroProvider(IPomodoroAsyncProvider provider)
        {
            _provider = provider;
        }

        public async Task<Pomodoro> Get(Guid id)
        {
            var cache = _pomodors.SingleOrDefault(p => p.Id == id);
            if (cache is not null)
                return cache;

            var pomodoro = await _provider.GetById(id);
            if (pomodoro is null)
                throw new PomodoroNotFoundException();

            _pomodors.Add(pomodoro);
            return pomodoro;
        }
    }
}
