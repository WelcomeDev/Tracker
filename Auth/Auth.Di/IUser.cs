using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using WelcomeDev.Provider.Di;

namespace Auth.Di
{
    public interface IUser : IGuid
    {
        string Username { get; }

        string Password { get; }
    }
}
