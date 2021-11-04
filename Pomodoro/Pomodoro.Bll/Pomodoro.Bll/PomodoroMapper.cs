using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
