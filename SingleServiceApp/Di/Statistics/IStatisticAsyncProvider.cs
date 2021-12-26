using SingleServiceApp.Bll.Statistics;
using SingleServiceApp.Controllers.Statistics.Dto;


namespace SingleServiceApp.Di.Statistics
{
    public interface IStatisticAsyncProvider
    {
        Task<IEnumerable<Statistic>> CreateStatistic(IEnumerable<StatisticCreationDto> data);

        Task<StatisticCollectionDto> GetAllStatisticByTag(SearchParamsDto paramsDto);

        Task<IEnumerable<Tag>> GetAllTags();
    }
}
