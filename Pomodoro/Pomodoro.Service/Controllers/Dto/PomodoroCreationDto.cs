using Pomodoro.Di;

namespace Pomodoro.Service.Controllers.Dto
{
    public class PomodoroCreationDto : IPomodoroEssentials
    {
        public string Title { get; set; }
        public TimeSpan RestDuration { get; set; }
        public TimeSpan WorkDuration { get; set; }
    }
}
