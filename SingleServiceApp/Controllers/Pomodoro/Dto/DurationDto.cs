
using SingleServiceApp.Di.Pomodoro.Duration;

using System.ComponentModel.DataAnnotations;

namespace SingleServiceApp.Controllers.Pomodoro.Dto
{
    public class DurationDto : IDuration
    {
        [Required(ErrorMessage = "Minutes are required")]
        [Range(0, 59, ErrorMessage = "Minutes must be between {1} and {2}")]
        public int Minutes { get; set; }

        [Required(ErrorMessage = "Hours are required")]
        [Range(0, 23, ErrorMessage = "Hours must be between {1} and {2}")]
        public int Hours { get; set; }
    }
}
