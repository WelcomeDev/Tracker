using Statistic.Di.Tag;

using WelcomeDev.Provider.Di;

namespace Statistic.Di
{
    public interface IStatistic : IGuid
    {
        public ITag Tag { get; set; }

        public string Title { get; set; }

        public double Value { get; }

        public DateTime Date { get; }
    }
}
