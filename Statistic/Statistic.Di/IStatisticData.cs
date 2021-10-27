using WelcomeDev.Provider.Di;

namespace Statistic.Di
{
    public interface IStatisticData : IGuid
    {
        public string Title { get; }

        public double Value { get; }
    }
}
