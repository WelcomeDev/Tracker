﻿using WelcomeDev.Provider.Di;

namespace Auth.Di
{
    public interface IUserIdentity : IGuid
    {
        string Name { get; }
    }
}
