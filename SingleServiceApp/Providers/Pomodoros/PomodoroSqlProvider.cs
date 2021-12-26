
using Microsoft.EntityFrameworkCore;

using SingleServiceApp.Di.Pomodoro;

using WelcomeDev.Provider.Di.Pageable;

namespace SingleServiceApp.Providers.Pomodoros
{
    public class PomodoroSqlProvider : IPomodoroAsyncProvider
    {
        private readonly PomodoroDbContext _context;

        //public PomodoroSqlProvider(PomodoroDbContext context)
        //{
        //    _context = context;
        //}

        public PomodoroSqlProvider(string connectionString)
        {
            _context = new PomodoroDbContext(connectionString);
        }

        private async Task<Pomodoro> GetInstance(Guid id)
        {
            return await _context.Pomodoros.Where(item => item.Id.Equals(id))
                                           .SingleOrDefaultAsync();
        }

        public async Task<IPomodoroData> Create(IPomodoroEssentials data)
        {
            var pomodoro = await _context.AddAsync(new Pomodoro(data));
            return pomodoro.Entity;
        }

        public async void Delete(Guid id)
        {
            var entity = await GetInstance(id);
            if (entity is not null)
                _context.Pomodoros.Remove(entity);
        }

        public async Task<IEnumerable<IPomodoroData>> GetAll()
        {
            return await _context.Pomodoros.AsNoTracking()
                                           .ToListAsync();
        }

        public async Task<PageableList<IPomodoroData>> GetAll(PageableParams pageable = null)
        {
            var all = await GetAll();
            return new PageableList<IPomodoroData>(all, pageable);
        }

        public async Task<IPomodoroData> GetById(Guid id)
        {
            var pomodoroItem = await GetInstance(id);
            return pomodoroItem;
        }

        public async Task<IPomodoroData> Update(Guid id, IPomodoroEssentials data)
        {
            var pomodoro = await GetInstance(id);

            pomodoro.Title = data.Title;
            pomodoro.WorkDuration.Minutes = data.WorkDuration.Minutes;
            pomodoro.WorkDuration.Hours = data.WorkDuration.Hours;

            pomodoro.RestDuration.Minutes = data.RestDuration.Minutes;
            pomodoro.RestDuration.Hours = data.RestDuration.Hours;

            await _context.SaveChangesAsync();

            return pomodoro;
        }
    }
}
