using Pomodoro.Di.Duration;

namespace Pomodoro.Bll.Provider.Mock.Additional
{
    internal class Duration : IDuration
    {
        public int Minutes { get; set; }

        public int Hours { get; set; }
    }
}
