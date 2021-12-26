using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

using SingleServiceApp.Bll.Auth;
using SingleServiceApp.Controllers.Pomodoro.Dto;

namespace SingleServiceApp.Bll.Pomodoros
{
    public partial class Pomodoro
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        public UserEntry User { get; set; }

        public string Title { get; set; }

        public Duration RestDuration { get; set; }

        public Duration WorkDuration { get; set; }

        public Pomodoro()
        {

        }

        public Pomodoro(CreatePomodoroDto createPomodoro, UserEntry user)
        {
            Title = createPomodoro.Title;
            RestDuration = createPomodoro.RestDuration;
            WorkDuration = createPomodoro.WorkDuration;
            User = user;
        }

        public bool Equals(Pomodoro other)
        {
            if (other is null)
                return false;

            return other.Title == Title;
        }
    }
}
