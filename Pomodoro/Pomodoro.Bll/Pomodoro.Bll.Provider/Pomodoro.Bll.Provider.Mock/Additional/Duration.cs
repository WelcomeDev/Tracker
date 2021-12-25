using Pomodoro.Di.Duration;

namespace Pomodoro.Bll.Provider.Mock.Additional
{
    public class Duration : IDuration
    {
        public int Minutes { get; set; }

        public int Hours { get; set; }
    }
}
