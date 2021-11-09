namespace Pomodoro.Service.Controllers.Exceptions
{
    public class PomodoroValidationException : ArgumentException
    {
        public PomodoroValidationException(string message) : base(message)
        { }
    }
}
