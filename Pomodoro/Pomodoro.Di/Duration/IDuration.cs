using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pomodoro.Di.Duration
{
    //TODO: extend actions
    public interface IDuration
    {
        int Minutes { get; set; }

        int Hours { get; set; }
    }
}
