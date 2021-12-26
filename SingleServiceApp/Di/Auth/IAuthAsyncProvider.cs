using SingleServiceApp.Bll.Auth;

namespace SingleServiceApp.Di.Auth
{
    public interface IAuthAsyncProvider
    {
        Task<User> GetUser(string username);

        Task<User> CreateUser(string username, string password);

        Task<User> GetUserByGuid(string guid);
    }
}
