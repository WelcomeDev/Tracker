
using Pomodoro.Di.Duration;

namespace Pomodoro.Di
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
