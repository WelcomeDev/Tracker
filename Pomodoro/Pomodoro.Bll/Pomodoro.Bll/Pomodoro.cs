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

        public bool IsRunning { get; }

        public IDuration RestDuration { get; set; }

        public IDuration WorkDuration { get; set; }

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
        }

        public void Cancel()
        {

        }

        public bool Equals(IPomodoro? other)
        {
            if (other is null)
                return false;

            other.Title = Title;
            throw new NotImplementedException();
        }

        public void Pause()
        {

        }

        public void Resume()
        {

        }

        public void Start()
        {
            Debug.WriteLine($"{Id} started");
        }
    }
}
