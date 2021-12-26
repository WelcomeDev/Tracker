using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Statistic.Di.Providers
{
    public static class StatisticMapper
    {
        public static IEnumerable<StatisticWebModelCollection> StatisticMap(IEnumerable<IStatistic> statistics)
        {
            List<StatisticWebModelCollection> res = new List<StatisticWebModelCollection>();
            var dates = statistics.Select(x => x.Date).Distinct();

            foreach (var date in dates)
                res.Add(new StatisticWebModelCollection()
                {
                    Date = date,
                    Models = statistics.Where(x => x.Date == date).Select(x => new StatisticWebModel(x))
                });

            return res;
        }
    }
}
