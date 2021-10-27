using Statistic.Di.Tag;

namespace Statistic.Di
{
    public interface IStatistic :IEquatable<IStatistic>, IStatisticData
    {
        public ITag Tag { get; set; }

        public string Title { set; }

        public DateTime Date { get; }
    }
}
