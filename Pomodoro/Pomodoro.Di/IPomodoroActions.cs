using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Pomodoro.Di.Duration;

namespace Pomodoro.Di
{
    public interface IPomodoroActions
    {
        bool IsRunning { get; }

        void Cancel();

        void Pause();

        void Resume();

        void Start();

        IDuration Status();
    }
}
