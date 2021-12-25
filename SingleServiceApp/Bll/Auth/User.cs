using Auth.Di;

using Microsoft.AspNetCore.Identity;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingleServiceApp.Bll.Auth
{
    internal class User
    {
        public Guid Id { get; set; }

        public string Name { get; set; }    

        public string Password { get; set; }
    }
}
