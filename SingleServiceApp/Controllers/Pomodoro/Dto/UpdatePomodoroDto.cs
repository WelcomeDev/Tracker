using Newtonsoft.Json;

using SingleServiceApp.Bll.Pomodoros;

using System.ComponentModel.DataAnnotations;

namespace SingleServiceApp.Controllers.Pomodoro.Dto
{
    public class UpdatePomodoroDto
    {
        [Required(ErrorMessage = "Id is required")]
        public Guid Id { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Pomodoro title is required")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Rest duration is required")]
        public Duration RestDuration { get; set; }

        [Required(ErrorMessage = "Word duration is required")]
        public Duration WorkDuration { get; set; }
    }
}
