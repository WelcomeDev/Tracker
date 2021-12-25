
using SingleServiceApp.Di.Pomodoro.Duration;

namespace SingleServiceApp.Di.Pomodoro
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
