using Pomodoro.Di.Duration;

namespace Pomodoro.Service.Controllers.Dto
{
    public class DurationDto : IDuration
    {
        public int Minutes { get; set; }

        public int Hours { get; set; }
    }
}
