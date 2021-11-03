using System.Text.Json;

using Auth.Di;

using Pomodoro.Bll.Provider.Mock.Properties;
using Pomodoro.Di;
using Pomodoro.Di.Provider;

namespace Pomodoro.Bll.Provider.Mock
{
    public class PomodoroMockProvider : IPomodoroProvider
    {
        private readonly IList<PomodoroData> _data;
        private readonly IUserIdentity _user;

        public PomodoroMockProvider(IUserIdentity user)
        {
            _data = JsonSerializer.Deserialize<List<PomodoroData>>(Resources.pomodoros);
            _user = user;
        }

        public IPomodoroData GetById(Guid id)
        {
            return _data.Single(x => x.Id == id);
        }

        public IPomodoroData Create(IPomodoroEssentials data)
        {
            var newItem = new PomodoroData(data, _user);
            _data.Add(newItem);
            return newItem;
        }

        public void Delete(Guid id)
        {
            var objToBeRemoved = _data.Single(x => x.Id == id);
            _data.Remove(objToBeRemoved);
        }

        public IEnumerable<IPomodoroData> GetAll()
        {
            return _data.Where(x => x.User.Id == _user.Id);
        }

        public IPomodoroData Update(IPomodoroData data)
        {
            var objToBeEdited = _data.Single(x => x.Id == data.User.Id);
            objToBeEdited.Title = data.Title;
            objToBeEdited.WorkDuration = data.WorkDuration;
            objToBeEdited.RestDuration = data.RestDuration;

            return objToBeEdited;
        }
    }
}
