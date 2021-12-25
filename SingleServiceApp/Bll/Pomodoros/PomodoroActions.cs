using System.Diagnostics;

namespace SingleServiceApp.Bll.Pomodoros
{
    public partial class Pomodoro
    {
        private DateTime? _start;

        public void Cancel()
        {
            _start = null;
            IsRunning = false;
            Debug.WriteLine($"{Title} canceled");
        }

        public void Pause()
        {
            IsRunning = false;
            Debug.WriteLine($"{Title} paused");
        }

        public void Resume()
        {
            IsRunning = true;
            Debug.WriteLine($"{Title} resumed");
        }

        public void Start()
        {
            _start = DateTime.UtcNow;
            IsRunning = true;
            Debug.WriteLine($"{Title} started");
        }

        public Duration Status()
        {
            if (!IsRunning)
                return null;

            var diff = (DateTime.UtcNow - _start).Value;
            return new Duration
            {
                Hours = diff.Hours,
                Minutes = diff.Minutes
            };
        }
    }
}
