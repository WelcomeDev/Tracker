using Auth.Di;
using Statistic.Di.Tag;
using Statistic.Di.Tittle;

namespace Statistic.Di
{
    public interface IStatistic
    {
        Guid Id { get; }

        IUserIdentity User { get; }

        ITag Tag { get; }

        DateTime Date { get; }

        ITitle Title { get; }

        double Value { get; }
    }
}
