using Pomodoro.Di.Duration;

namespace Pomodoro.Di
{
    public interface IPomodoroEssentials
    {
        string Title { get; set; }

        IDuration RestDuration { get; set; }

        IDuration WorkDuration { get; set; }
    }
}
