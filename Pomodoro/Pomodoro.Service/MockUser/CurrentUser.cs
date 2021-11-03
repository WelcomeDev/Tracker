using Auth.Di;

namespace Pomodoro.Service.MockUser
{
    public class CurrentUser : IUserIdentity
    {
        public string Name { get; } = "admin";

        public Guid Id { get; } = new Guid("b41a9f1b-9c27-4985-9ba8-55d32614591d");
    }
}
