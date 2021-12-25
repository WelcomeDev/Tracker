using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Auth.Di;

using SingleServiceApp.Bll.Auth;

using Statistic.Di;
using Statistic.Di.Tag;
using Statistic.Di.Tittle;

namespace SingleServiceApp.Bll.Statistics
{
    public class Statistic : IStatistic
    {
        public Statistic(IStatistic data)
        {
            User = data.User;
        }

        public Statistic()
        {

        }

        public UserEntry User { get; set; }

        public Tag Tag { get; set; }

        public Title Title { get; set; }

        public DateTime Date { get; set; }

        public double Value { get; set; }

        public Guid Id { get; set; }

        ITitle IStatistic.Title => Title;

        ITag IStatistic.Tag => Tag;
    }
}
