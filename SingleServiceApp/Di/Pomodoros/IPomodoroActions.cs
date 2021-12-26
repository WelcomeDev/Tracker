using SingleServiceApp.Di.Pomodoros.Duration;

namespace SingleServiceApp.Di.Pomodoros
{
    public interface IPomodoroActions
    {
        bool IsRunning { get; }

        void Cancel();

        void Pause();

        void Resume();

        void Start();

        IDuration Status();
    }
}
