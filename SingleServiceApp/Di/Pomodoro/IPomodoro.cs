namespace SingleServiceApp.Di.Pomodoro
{
    public interface IPomodoro : IPomodoroData, IPomodoroActions, IEquatable<IPomodoro>
    {
    }
}
