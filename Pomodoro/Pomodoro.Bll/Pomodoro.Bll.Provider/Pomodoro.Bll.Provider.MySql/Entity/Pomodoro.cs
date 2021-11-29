using Auth.Di;

using Pomodoro.Di;
using Pomodoro.Di.Duration;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pomodoro.Bll.Provider.MySql.Entity
{
    public class Pomodoro : IPomodoroData
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [MaxLength(20)]
        [Required]
        public string Title { get; set; }

        [Required]
        public Duration RestDuration { get; set; }

        [Required]
        public Duration WorkDuration { get; set; }

        [Required]
        public Guid UserId { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; }

        [NotMapped]
        IUserIdentity IPomodoroData.User => throw new NotImplementedException();

        [NotMapped]
        IDuration IPomodoroEssentials.RestDuration { get => RestDuration; set => throw new NotImplementedException(); }

        [NotMapped]
        IDuration IPomodoroEssentials.WorkDuration { get => WorkDuration; set => throw new NotImplementedException(); }

        public Pomodoro()
        {

        }

        public Pomodoro(IPomodoroEssentials pomodoro)
        {
            Title = pomodoro.Title;
            RestDuration = new Duration(pomodoro.RestDuration);
            WorkDuration = new Duration(pomodoro.WorkDuration);
            //TODO: pass user here
        }
    }
}
