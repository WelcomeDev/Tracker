using Auth.Di;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Statistic.Bll.Provider.MySql.Entity
{
    [ComplexType]
    public class User : IUserIdentity
    {
        public User(IUserIdentity data)
        {
            UserName = data.UserName;
        }

        public Guid Id { get; set; }

        public string UserName { get; set; }
    }
}
