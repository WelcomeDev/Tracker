namespace SingleServiceApp.Providers.Statistics
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
