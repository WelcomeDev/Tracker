using SingleServiceApp.Bll.Statistics;
using SingleServiceApp.Controllers.Statistics.Dto;

namespace SingleServiceApp.Providers.Statistics
{
    public static class StatisticMapper
    {
        public static IEnumerable<StatisticCollectionDto> StatisticMap(IEnumerable<Statistic> statistics)
        {
            List<StatisticCollectionDto> res = new List<StatisticCollectionDto>();
            var dates = statistics.Select(x => x.Date).Distinct();

            foreach (var date in dates)
                res.Add(new StatisticCollectionDto
                {
                    Date = date,
                    Models = statistics.Where(x => x.Date == date).Select(x => new StatisticDto(x))
                });

            return res;
        }
    }
}
