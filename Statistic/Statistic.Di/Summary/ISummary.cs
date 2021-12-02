using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Statistic.Di.Tag;

namespace Statistic.Di.Summary
{
    public interface ISummary
    {
        public DateTime DateFrom { get; }

        public DateTime DateTo { get; }

        public Dictionary<ITag, IStatisticData> Values { get; }
    }
}
