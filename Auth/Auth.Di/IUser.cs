
using WelcomeDev.Provider.Di;

namespace Auth.Di
{
    public interface IUser : IGuid
    {
        string Username { get; }

        string Password { get; }
    }
}
