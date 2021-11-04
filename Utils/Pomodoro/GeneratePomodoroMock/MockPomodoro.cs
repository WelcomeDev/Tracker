using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

using Auth.Di;

using Pomodoro.Di;
using Pomodoro.Di.Duration;

namespace GeneratePomodoroMock
{
    internal class MockPomodoro : IPomodoroData
    {
        public IUserIdentity User { get; set; }

        public string Title { get; set; }

        public Guid Id { get; set; }

        public IDuration RestDuration { get; set; }

        public IDuration WorkDuration { get; set; }
    }
}
