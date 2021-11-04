using Auth.Di;

using Pomodoro.Di;
using Pomodoro.Di.Duration;

namespace Pomodoro.Bll.Provider.Mock
{
    internal class PomodoroData : IPomodoroData
    {
        public IUserIdentity User { get; set; }

        public string Title { get; set; }

        public Guid Id { get; set; }

        public IDuration RestDuration { get; set; }

        public IDuration WorkDuration { get; set; }

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
