using SingleServiceApp.Bll.Auth;

namespace SingleServiceApp.Di.Auth
{
    public interface IAuthAsyncProvider
    {
        Task<User> GetUser(string username);
    }
}
