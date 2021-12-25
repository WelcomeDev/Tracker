using Auth.Di;

namespace Pomodoro.Service.Services
{
    public class AuthFeignService : IAuthFeign
    {
        public async Task<IUserIdentity> GetCurrentUser()
        {
            throw new NotImplementedException();
        }
    }
}
