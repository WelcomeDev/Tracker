using WelcomeDev.Provider.Di;

namespace Statistic.Di.Tag
{
    public interface ITag : IGuid
    {
        string Title { get; set; }
    }
}
