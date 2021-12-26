using SingleServiceApp.Di.Pomodoros.Duration;

namespace SingleServiceApp.Di.Pomodoros
{
    public interface IPomodoroEssentials
    {
        string Title { get; set; }

        IDuration RestDuration { get; set; }

        IDuration WorkDuration { get; set; }
    }
}
