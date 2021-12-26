using Auth.Di;

using SingleServiceApp.Di.Pomodoros;
using SingleServiceApp.Di.Pomodoros.Duration;

namespace SingleServiceApp.Controllers.Pomodoro.Dto
{
    public class PomodoroDto : IPomodoroData
    {
        public IUserIdentity User { get; set; }

        public Guid Id { get; set; }

        public string Title { get; set; }

        public IDuration RestDuration { get; set; }

        public IDuration WorkDuration { get; set; }
    }
}
