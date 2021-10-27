using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pomodoro.Di
{
    public interface IPomodoroData
    {
        bool IsRunning { get; }

        string Title { get; set; }

        TimeSpan Duration { get; set; }

        DateTime StartDate { get; }
    }
}
