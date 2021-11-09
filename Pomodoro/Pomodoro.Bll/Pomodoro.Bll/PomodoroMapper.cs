
using Pomodoro.Di;

namespace Pomodoro.Bll
{
    public class PomodoroMapper : IPomodoroMapper
    {
        public IPomodoro ToPomodoro(IPomodoroData data)
        {
            return new Pomodoro(data);
        }
    }
}
