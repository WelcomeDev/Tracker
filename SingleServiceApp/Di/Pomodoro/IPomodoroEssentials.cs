
using SingleServiceApp.Di.Pomodoro.Duration;

namespace SingleServiceApp.Di.Pomodoro
{
    public interface IPomodoroEssentials
    {
        string Title { get; set; }

        IDuration RestDuration { get; set; }

        IDuration WorkDuration { get; set; }
    }
}
