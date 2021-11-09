using Auth.Di;

using WelcomeDev.Provider.Di;

namespace Pomodoro.Di
{
    public interface IPomodoroData : IGuid, IPomodoroEssentials
    {
        IUserIdentity User { get; }
    }
}
