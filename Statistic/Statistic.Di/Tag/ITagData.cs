using Auth.Di;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Statistic.Di.Tag
{
    public interface ITagData
    {
        IUserIdentity User { get; }

        Guid Id { get; }

        string Name { get; set; }
    }
}
