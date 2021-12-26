using SingleServiceApp.Bll.Pomodoros;

namespace SingleServiceApp.Controllers.Pomodoro.Dto
{
    public class PomodoroDto
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public Duration RestDuration { get; set; }

        public Duration WorkDuration { get; set; }
    }
}
