using Auth.Di;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Statistic.Bll
{

    internal class User : IUserIdentity
    {
        public string UserName { get; }

        public Guid UserId { get; set; }
    }
}
