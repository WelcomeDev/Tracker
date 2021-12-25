using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auth.Di
{
    public interface IAuthFeign
    {
        Task<IUserIdentity> GetCurrentUser();
    }
}
