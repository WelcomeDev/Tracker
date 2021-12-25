
using Pomodoro.Di.Duration;

namespace Pomodoro.Bll
{
    internal class Duration : IDuration
    {
        public int Minutes { get; set; }

        public int Hours { get; set; }
    }
}
