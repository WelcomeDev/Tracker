namespace Pomodoro.Di.Provider
{
    public interface IPomodoroProvider
    {
        IPomodoroData GetById(Guid id);

        Task Create(IPomodoroData data);

        Task Delete(Guid id);

        Task<IEnumerable<IPomodoroData>> GetAll();

        Task Update(IPomodoroData data);
    }
}
