using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pomodoro.Di
{
    public interface IPomodoro : IPomodoroData, IPomodoroActions, IEquatable<IPomodoro>
    {
    }
}
