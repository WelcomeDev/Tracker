using System;
using System.Collections.Generic;
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
        public IUserIdentity User => throw new NotImplementedException();

        public Guid Id { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Title { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public bool IsRunning => throw new NotImplementedException();

        public IDuration RestDuration { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public IDuration WorkDuration { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public Pomodoro()
        {

        }

        public Pomodoro(IPomodoroData data)
        {

        }

        public void Cancel() => throw new NotImplementedException();
        public bool Equals(IPomodoro? other)
        {
            if (other is null)
                return false;

            other.Title = Title;
            throw new NotImplementedException();
        }
        public void Pause() => throw new NotImplementedException();
        public void Resume() => throw new NotImplementedException();
        public void Start() => throw new NotImplementedException();
    }
}
