using Auth.Di;
using Statistic.Di.Tag;

namespace Statistic.Di
{
    public interface IStatisticData : IStatisticEssentialsData
    {
        IUserIdentity User { get; }

        ITag Tag { get; }

        DateTime Date { get; }
    }
}
