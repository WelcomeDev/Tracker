using Statistic.Di.Tag;

using WelcomeDev.Provider.Di;

namespace Statistic.Di
{
    public interface IStatistic : IGuid, IEquatable<IStatistic>, IStatisticData
    {
        public ITag Tag { get; set; }

        public string Title { set; }

        public DateTime Date { get; }
    }
}
