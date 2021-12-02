using Auth.Di;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Statistic.Bll
{
    internal class User : IUserIdentity
    {
        public string Name { get; }

        public Guid Id { get; set; }
    }
}
