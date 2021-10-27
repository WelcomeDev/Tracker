using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Statistic.Di
{
    public interface IStatisticData
    {
        public string Title { get; }

        public double Value { get; }
    }
}
