using Auth.Di;
using Statistic.Di.Tag;

namespace Statistic.Di
{
    public interface IStatisticData : IStatisticEssentialsData
    {
        IUserIdentity User { get; }

        ITag Tag { get; set; }

        string Title { set; }

        DateTime Date { get; }
    }
}
