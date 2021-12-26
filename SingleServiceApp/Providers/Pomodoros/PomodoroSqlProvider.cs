
using Microsoft.EntityFrameworkCore;

using SingleServiceApp.Bll.Auth;
using SingleServiceApp.Bll.Pomodoros;
using SingleServiceApp.Controllers.Pomodoro.Dto;
using SingleServiceApp.Di.Pomodoros;

using WelcomeDev.Provider.Di.Pageable;

namespace SingleServiceApp.Providers.Pomodoros
{
    public class PomodoroSqlProvider : IPomodoroAsyncProvider
    {
        private readonly PomodoroDbContext _context;
        //todo: get curent user!
        //todo: auth!
        private readonly UserEntry _user;

        public PomodoroSqlProvider()
        {
            _context = new PomodoroDbContext();
        }

        private async Task<Pomodoro> GetInstance(Guid id)
        {
            return await _context.Pomodoros.Where(item => item.Id.Equals(id))
                                           .SingleOrDefaultAsync();
        }

        public async Task<Pomodoro> Create(CreatePomodoroDto data)
        {
            var pomodoro = await _context.AddAsync(new Pomodoro(data, _user));
            return pomodoro.Entity;
        }

        public async void Delete(Guid id)
        {
            var entity = await GetInstance(id);
            if (entity is not null)
                _context.Pomodoros.Remove(entity);
        }

        public async Task<IEnumerable<Pomodoro>> GetAll()
        {
            return await _context.Pomodoros.AsNoTracking()
                                           .ToListAsync();
        }

        public async Task<PageableList<Pomodoro>> GetAll(PageableParams pageable = null)
        {
            var all = await GetAll();
            return new PageableList<Pomodoro>(all, pageable);
        }

        public async Task<Pomodoro> GetById(Guid id)
        {
            var pomodoroItem = await GetInstance(id);
            return pomodoroItem;
        }

        public async Task<Pomodoro> Update(Guid id, UpdatePomodoroDto data)
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
