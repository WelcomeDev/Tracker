namespace Pomodoro.Service.Controllers.Exceptions
{
    public class PomodoroException : ArgumentException
    {
        public PomodoroException(string message) : base(message)
        { }
    }
}
