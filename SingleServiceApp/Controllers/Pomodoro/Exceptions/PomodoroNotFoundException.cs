namespace SingleServiceApp.Controllers.Pomodoro.Exceptions
{
    public class PomodoroNotFoundException : Exception
    {
        private const string ErrorMessage = "Required pomodoro not found";
        public PomodoroNotFoundException() : base(ErrorMessage)
        { }
    }
}
