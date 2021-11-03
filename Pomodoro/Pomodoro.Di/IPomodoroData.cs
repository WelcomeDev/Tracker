using Auth.Di;

using WelcomeDev.Provider.Di;

namespace Pomodoro.Di
{
    public interface IPomodoroData : IGuid
    {
        IUserIdentity User { get; }

        string Title { get; set; }

        TimeSpan RestDuration { get; set;  }

        TimeSpan WorkDuration { get; set; }
    }
}
