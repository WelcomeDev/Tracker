using System;
using System.Diagnostics;

using Auth.Di;

using Pomodoro.Bll;

using SingleServiceApp.Bll.Auth;
using SingleServiceApp.Bll.Pomodoro;

using SingleServiceApp.Di.Pomodoro;
using SingleServiceApp.Di.Pomodoro.Duration;

namespace SingleServiceApp.Bll.Pomodoros
{
    public partial class Pomodoro : IPomodoro
    {
        public UserEntry User { get; }

        public Guid Id { get; set; }

        public string Title { get; set; }

        public bool IsRunning { get; private set; }

        public Duration RestDuration { get; set; }

        public Duration WorkDuration { get; set; }

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

        public bool Equals(Pomodoro other)
        {
            if (other is null)
                return false;

            return other.Title == Title;
        }
    }
}
