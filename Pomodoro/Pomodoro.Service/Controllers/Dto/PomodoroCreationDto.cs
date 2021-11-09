using Pomodoro.Di;
using Pomodoro.Di.Duration;

namespace Pomodoro.Service.Controllers.Dto
{
    public class PomodoroCreationDto : IPomodoroEssentials
    {
        public string Title { get; set; }
        public IDuration RestDuration { get; set; }
        public IDuration WorkDuration { get; set; }
    }
}
