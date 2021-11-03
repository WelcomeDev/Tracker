using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Pomodoro.Di;
using Pomodoro.Di.Provider;

namespace Pomodoro.Bll.Provider.Mock
{
    public class PomodoroMockProvider : IPomodoroProvider
    {
        public Task Create(IPomodoroData data) => throw new NotImplementedException();
        public Task Delete(Guid id) => throw new NotImplementedException();
        public Task<IEnumerable<IPomodoroData>> GetAll() => throw new NotImplementedException();
        public IPomodoroData GetById(Guid id) => throw new NotImplementedException();
        public Task Update(IPomodoroData data) => throw new NotImplementedException();
    }
}
