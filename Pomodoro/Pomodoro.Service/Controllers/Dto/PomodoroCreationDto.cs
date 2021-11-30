using Pomodoro.Di;
using Pomodoro.Di.Duration;

using System.ComponentModel.DataAnnotations;

namespace Pomodoro.Service.Controllers.Dto
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
