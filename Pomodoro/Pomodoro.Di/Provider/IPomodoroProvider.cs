using WelcomeDev.Provider.Di.Pageable;

namespace Pomodoro.Di.Provider
{
    public interface IPomodoroProvider : IPageableProvider<IPomodoroData>
    {
        IPomodoroData GetById(Guid id);

        IPomodoroData Create(IPomodoroEssentials data);

        void Delete(Guid id);

        IEnumerable<IPomodoroData> GetAll();

        IPomodoroData Update(Guid id, IPomodoroEssentials data);
    }
}
