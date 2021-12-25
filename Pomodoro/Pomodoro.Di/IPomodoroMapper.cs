namespace Pomodoro.Di
{
    public interface IPomodoroMapper
    {
        IPomodoro ToPomodoro(IPomodoroData data);
    }
}
