using Auth.Di;

namespace Pomodoro.Di
{
    public interface IPomodoroData
    {
        IUserIdentity User { get; }

        bool IsRunning { get; }

        string Title { get; set; }

        TimeSpan Duration { get; set; }

        DateTime StartDate { get; }
    }
}
