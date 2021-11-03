namespace Pomodoro.Di
{
    public interface IPomodoroEssentials
    {
        string Title { get; set; }

        TimeSpan RestDuration { get; set; }

        TimeSpan WorkDuration { get; set; }
    }
}
