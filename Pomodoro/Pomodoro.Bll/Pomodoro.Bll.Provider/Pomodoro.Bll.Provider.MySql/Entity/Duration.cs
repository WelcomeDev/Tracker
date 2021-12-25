
using Pomodoro.Di.Duration;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pomodoro.Bll.Provider.MySql.Entity
{
    [ComplexType]
    public class Duration : IDuration
    {
        [Range(0, 8)]
        public int Hours { get; set; }
        [Range(0, 59)]
        public int Minutes { get; set; }

        public Duration()
        {

        }

        public Duration(IDuration duration)
        {
            Hours = duration.Hours;
            Minutes = duration.Minutes;
        }
    }
}
