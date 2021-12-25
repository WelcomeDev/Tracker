using Microsoft.AspNetCore.Mvc;

using SingleServiceApp.Controllers.Statistics.Dto;
using SingleServiceApp.Di.Statistics;

using Statistic.Service.Controllers.Dto;

namespace SingleServiceApp.Controllers.Statistics
{
    [ApiController]
    [Route("api/statistic")]
    public class StatisticController : ControllerBase
    {
        private readonly IStatisticAsyncProvider _provider;

        public StatisticController(IStatisticAsyncProvider provider)
        {
            _provider = provider;
        }

        [HttpGet]
        [Route("list")]
        public async Task<IEnumerable<StatisticWebModelCollection>> GetAllByTag([FromRoute] SearchParamsDto paramsDto)
        {
            var pomodoro = await _provider.GetAllStatisticByTag(paramsDto);

            return pomodoro;
        }

    }
}
