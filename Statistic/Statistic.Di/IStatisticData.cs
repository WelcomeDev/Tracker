using Auth.Di;
using Statistic.Di.Tag;
using Statistic.Di.Tittle;

namespace Statistic.Di
{
    public interface IStatisticData 
    {
        Guid Id { get; }

        IUserIdentity User { get; }

        ITagData Tag { get; }

        DateTime Date { get; }

        ITitleData Title { get; }

        double Value { get; }
    }
}
