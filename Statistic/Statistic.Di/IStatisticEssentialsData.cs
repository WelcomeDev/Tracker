using WelcomeDev.Provider.Di;

namespace Statistic.Di
{
    public interface IStatisticEssentialsData : IGuid
    {
        public IStatisticSubject Subject { get; }

        public double Value { get; }
    }
}
