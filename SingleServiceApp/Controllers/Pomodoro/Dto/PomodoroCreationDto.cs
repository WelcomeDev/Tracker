
using SingleServiceApp.Di.Pomodoro;
using SingleServiceApp.Di.Pomodoro.Duration;

using System.ComponentModel.DataAnnotations;

namespace SingleServiceApp.Controllers.Pomodoro.Dto
{
    public class PomodoroCreationDto : IPomodoroEssentials
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Pomodoro title is required")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Rest duration is required")]
        public IDuration RestDuration { get; set; }

        [Required(ErrorMessage = "Word duration is required")]
        public IDuration WorkDuration { get; set; }
    }
}
