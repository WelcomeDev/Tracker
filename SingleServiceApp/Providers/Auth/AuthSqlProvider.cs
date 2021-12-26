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

        public async Task<User> GetUserByGuid(string guid)
        {
            return await _context.Users.SingleOrDefaultAsync(x => x.Id == new Guid(guid));
        }

        public async Task<User> GetUser(string username)
        {
            return await _context.Users.SingleOrDefaultAsync(x => x.Login.Equals(username));
        }

        public async Task<User> CreateUser(string username, string password)
        {
            await CheckUsernameExistance(username);

            var user = await _context.AddAsync(new User { Login = username, Password = password });
            await _context.SaveChangesAsync();

            return user.Entity;
        }

        private async Task CheckUsernameExistance(string username)
        {
            var user = await _context.Users.SingleOrDefaultAsync(x => x.Login.Equals(username));
            if (user == null)
                return;

            throw new ArgumentException($"User {username} already exists, please try other");
        }
    }
}
