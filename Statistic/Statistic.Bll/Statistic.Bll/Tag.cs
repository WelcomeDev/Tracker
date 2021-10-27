using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Statistic.Di.Tag;

namespace Statistic.Bll.Tag
{
    internal class Tag : ITag
    {
        public string Title { get; set; }
        public Guid Id { get; set; }

        public bool Equals(ITag? other)
        {
            if (other is null)
                return false;

            return Title.Equals(other.Title);
        }
    }
}
