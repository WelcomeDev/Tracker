using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Auth.Di;

using Pomodoro.Di;

namespace Pomodoro.Bll.Provider.Mock
{
    internal class PomodoroData : IPomodoroData
    {
        public IUserIdentity User => throw new NotImplementedException();

        public string Title { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public IDuration Rest => throw new NotImplementedException();

        public IDuration Work => throw new NotImplementedException();

        public Guid Id { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
