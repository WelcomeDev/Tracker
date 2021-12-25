using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Auth.Di;
using Statistic.Di.Tag;

namespace Statistic.Bll.Tag
{
    internal class Tag : ITag
    {

        public string Name { get; set; }
        public Guid Id { get; set; }

        public User User { get; set; }
        public double? MaxValue { get; set; }

        IUserIdentity ITag.User => User;

        public bool Equals(ITag? other)
        {
            if (other is null)
                return false;

            return Name.Equals(other.Name);
        }
    }
}
