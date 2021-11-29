using WelcomeDev.Provider.Di.Pageable;

namespace Pomodoro.Di.Provider
{
    public interface IPomodoroAsyncProvider : IPageableAsyncProvider<IPomodoroData>
    {
        Task<IPomodoroData> GetById(Guid id);

        Task<IPomodoroData> Create(IPomodoroEssentials data);

        void Delete(Guid id);

        Task<IEnumerable<IPomodoroData>> GetAll();

        Task<IPomodoroData> Update(Guid id, IPomodoroEssentials data);
    }
}
