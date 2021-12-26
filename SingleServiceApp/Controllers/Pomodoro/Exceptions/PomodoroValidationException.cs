namespace SingleServiceApp.Controllers.Pomodoro.Exceptions
{
    public class PomodoroValidationException : ArgumentException
    {
        public PomodoroValidationException(string message) : base(message)
        { }
    }
}
