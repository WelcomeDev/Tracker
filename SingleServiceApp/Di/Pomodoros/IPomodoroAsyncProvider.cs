
using SingleServiceApp.Bll.Pomodoros;
using SingleServiceApp.Controllers.Pomodoro.Dto;

using WelcomeDev.Provider.Di.Pageable;

namespace SingleServiceApp.Di.Pomodoros
{
    public interface IPomodoroAsyncProvider : IPageableAsyncProvider<Pomodoro>
    {
        Task<Pomodoro> GetById(Guid id);

        Task<Pomodoro> Create(CreatePomodoroDto data);

        void Delete(Guid id);

        Task<IEnumerable<Pomodoro>> GetAll();

        Task<Pomodoro> Update(Guid id, UpdatePomodoroDto data);
    }
}
