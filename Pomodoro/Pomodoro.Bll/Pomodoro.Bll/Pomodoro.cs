using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Auth.Di;

using Pomodoro.Di;
using Pomodoro.Di.Duration;

namespace Pomodoro.Bll
{
    public class Pomodoro : IPomodoro
    {
        public IUserIdentity User { get; }

        public Guid Id { get; set; }
        public string Title { get; set; }

        public bool IsRunning { get; private set; }

        public IDuration RestDuration { get; set; }

        public IDuration WorkDuration { get; set; }

        private DateTime? _start;

        public Pomodoro()
        {

        }

        public Pomodoro(IPomodoroData data)
        {
            User = data.User;
            Id = data.Id;
            Title = data.Title;
            RestDuration = data.RestDuration;
            WorkDuration = data.WorkDuration;
            _start = null;
        }

        public void Cancel()
        {
            _start = null;
            IsRunning = false;
            Debug.WriteLine($"{Title} canceled");
        }

        public bool Equals(IPomodoro? other)
        {
            if (other is null)
                return false;

            return other.Title == Title;
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

        public IDuration Status()
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
