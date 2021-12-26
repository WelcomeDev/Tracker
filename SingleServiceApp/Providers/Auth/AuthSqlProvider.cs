using Microsoft.EntityFrameworkCore;

using SingleServiceApp.Bll.Auth;
using SingleServiceApp.Di.Auth;

namespace SingleServiceApp.Providers.Auth
{
    public class AuthSqlProvider : IAuthAsyncProvider
    {
        private readonly AuthDbContext _context;

        public AuthSqlProvider()
        {
            _context = new AuthDbContext();
        }

        public async Task<User> GetUser(string username)
        {
            return await _context.Users.SingleAsync(x=>x.Name.Equals(username));
        }
    }
}
