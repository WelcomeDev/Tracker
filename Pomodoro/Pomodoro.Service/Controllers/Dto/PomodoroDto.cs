using Auth.Di;
using Pomodoro.Di;
using Pomodoro.Di.Duration;

namespace Pomodoro.Service.Controllers.Dto
{
    public class PomodoroDto : IPomodoroData
    {
        public IUserIdentity User => throw new NotImplementedException();

        public Guid Id { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Title { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public IDuration RestDuration { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public IDuration WorkDuration { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
