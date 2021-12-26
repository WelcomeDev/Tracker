using SingleServiceApp.Bll.Statistics;
using SingleServiceApp.Controllers.Statistics.Dto;
using SingleServiceApp.Providers.Statistics.Arguments;

namespace SingleServiceApp.Di.Statistics
{
    public interface IStatisticAsyncProvider
    {
        Task<IEnumerable<Statistic>> CreateStatistic(IEnumerable<StatisticCreationDto> data);

        Task<StatisticCollectionDto> GetAllStatisticByTag(StatisticSearchArguments paramsDto); 
        Task<IEnumerable<Title>> GetAllTitlesByTag(string tagName);

        Task<IEnumerable<Tag>> GetAllTags();
    }
}
