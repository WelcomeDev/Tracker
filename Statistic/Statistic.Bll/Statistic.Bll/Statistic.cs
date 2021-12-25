using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Auth.Di;

using Statistic.Di;
using Statistic.Di.Tag;
using Statistic.Di.Tittle;

namespace Statistic.Bll
{
    public class Statistic : IStatistic
    {
        public Statistic(IStatistic data)
        {
            User = data.User;
        }

        public IUserIdentity User { get; set; }

        public ITag Tag { get; set; }

        public ITitle Title { get; set; }

        public DateTime Date { get; set; }

        public double Value { get; set; }

        public Guid Id { get; set; }

        ITitle IStatistic.Title => Title;

        ITag IStatistic.Tag => Tag;
    }
}
