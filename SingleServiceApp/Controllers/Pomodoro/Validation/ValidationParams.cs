using SingleServiceApp.Bll.Pomodoros;

namespace SingleServiceApp.Controllers.Pomodoro.Validation
{
    public class ValidationParams
    {
        public string Title { get; set; }

        public Duration RestDuration { get; set; }

        public Duration WorkDuration { get; set; }
    }
}
