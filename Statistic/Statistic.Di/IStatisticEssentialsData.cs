using WelcomeDev.Provider.Di;

namespace Statistic.Di
{
    public interface IStatisticEssentialsData : IGuid
    {
        public string Title { get; }

        public double Value { get; }
    }
}
