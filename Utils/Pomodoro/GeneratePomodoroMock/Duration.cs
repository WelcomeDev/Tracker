
using Pomodoro.Di.Duration;

namespace GeneratePomodoroMock
{
    internal class Duration : IDuration
    {
        public int Minutes { get; set; }
        public int Hours { get; set; }
    }
}
