using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SingleServiceApp.Bll.Pomodoros
{
    [ComplexType]
    public class Duration
    {
        [Range(0, 59, ErrorMessage = "Minutes must be in range from {1} to {2}")]
        public int Minutes { get; set; }

        [Range(0, 8, ErrorMessage = "Hours must be in range from {1} to {2}")]
        public int Hours { get; set; }
    }
}
