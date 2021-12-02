using WelcomeDev.Provider.Di;

namespace Auth.Di
{
    public interface IUserIdentity
    {
        string UserName { get; }
    }
}
