using Auth.Di;

using Pomodoro.Di;

namespace Pomodoro.Bll.Provider.Mock
{
    internal class PomodoroData : IPomodoroData
    {
        public IUserIdentity User { get; set; }

        public string Title { get; set; }
        public TimeSpan RestDuration { get; set; }
        public TimeSpan WorkDuration { get; set; }
        public Guid Id { get; set; }

        public PomodoroData()
        { }

        public PomodoroData(IPomodoroEssentials data, IUserIdentity user)
        {
            Id = Guid.NewGuid();
            User = user;
            Title = data.Title;
            RestDuration = data.RestDuration;
            WorkDuration = data.WorkDuration;
        }
    }
}
