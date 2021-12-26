using SingleServiceApp.Bll.Statistics;
using SingleServiceApp.Controllers.Statistics.Dto;

namespace SingleServiceApp.Providers.Statistics
{
    public static class StatisticMapper
    {
        public static StatisticCollectionDto StatisticMap(IEnumerable<Statistic> statistics)
        {
            StatisticCollectionDto statCollection = new StatisticCollectionDto();
            var dates = statistics.Select(x => x.Date).Distinct().OrderBy(x => x);

            statCollection.Dates = dates.Select(x => x.ToString("yyyy-MM-dd"));
            statCollection.Models = new List<StatisticDto>();

            var uniquTitles = statistics.Select(x => x.Title).Distinct();

            foreach (var title in uniquTitles)
            {
                var valueItem = new StatisticDto
                {
                    Title = title.Name,
                    Color = title.ColorSql.ToString(),
                };

                // для каждого тайтла я достаю его статистики и упорядочиваю по дате
                var titlesStats = statistics.Where(x => x.TitleId == title.Id)
                                            .OrderBy(x => x.Date);
                var res = new List<double?>();

                foreach (var date in dates)
                {
                    if (titlesStats.Select(x => x.Date).Contains(date))
                        res.Add(titlesStats.First(x => x.Date == date).Value);
                    else
                        res.Add(null);
                }

                valueItem.Value = res;

                statCollection.Models.Add(valueItem);
            }

            return statCollection;
        }
    }
}
