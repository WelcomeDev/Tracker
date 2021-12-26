using Auth.Di;

using WelcomeDev.Provider.Di;

namespace SingleServiceApp.Di.Pomodoros
{
    public interface IPomodoroData : IGuid, IPomodoroEssentials, IComparable<IPomodoroData>
    {
        IUserIdentity User { get; }

        int IComparable<IPomodoroData>.CompareTo(IPomodoroData other)
        {
            if (other == null)
                throw new ArgumentNullException("other");

            return Title.CompareTo(other.Title);
        }
    }
}
