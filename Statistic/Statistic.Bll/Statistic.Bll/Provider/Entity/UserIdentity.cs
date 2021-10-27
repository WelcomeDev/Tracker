using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Auth.Di;

namespace Statistic.Bll.Provider.Entity
{
    [ComplexType]
    internal class UserIdentity : IUserIdentity
    {
        public string Name { get; set; }

        public Guid Id { get; set; }
    }
}
