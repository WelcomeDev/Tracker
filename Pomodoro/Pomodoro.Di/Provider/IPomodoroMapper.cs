namespace Pomodoro.Di.Provider
{
    public interface IPomodoroMapper
    {
        IPomodoro ToPomodoro(IPomodoroData data);
    }
}
