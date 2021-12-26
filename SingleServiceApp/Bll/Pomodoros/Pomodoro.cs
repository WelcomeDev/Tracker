using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

using SingleServiceApp.Bll.Auth;

namespace SingleServiceApp.Bll.Pomodoros
{
    public partial class Pomodoro
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        public UserEntry User { get; }

        public string Title { get; set; }

        public bool IsRunning { get; private set; }

        public Duration RestDuration { get; set; }

        public Duration WorkDuration { get; set; }

        public Pomodoro()
        {

        }

        public bool Equals(Pomodoro other)
        {
            if (other is null)
                return false;

            return other.Title == Title;
        }
    }
}
