using WelcomeDev.Provider.Di;

namespace Statistic.Di.Tag
{
    public interface ITag : IGuid, IEquatable<ITag>
    {
        string Title { get; set; }
    }
}
