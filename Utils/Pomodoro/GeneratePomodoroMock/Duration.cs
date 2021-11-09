using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Pomodoro.Di.Duration;

namespace GeneratePomodoroMock
{
    internal class Duration : IDuration
    {
        public int Minutes { get; set; }
        public int Hours { get; set; }
    }
}
