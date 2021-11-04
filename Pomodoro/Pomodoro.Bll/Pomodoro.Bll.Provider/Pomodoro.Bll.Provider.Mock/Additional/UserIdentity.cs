using Auth.Di;

namespace Pomodoro.Bll.Provider.Mock.Additional
{
    internal class UserIdentity : IUserIdentity
    {
        public string Name { get; set; }

        public Guid Id { get; set; }
    }
}
