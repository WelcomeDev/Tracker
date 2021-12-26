namespace SingleServiceApp.Di.Pomodoros
{
    public interface IPomodoro : IPomodoroData, IPomodoroActions, IEquatable<IPomodoro>
    {
    }
}
