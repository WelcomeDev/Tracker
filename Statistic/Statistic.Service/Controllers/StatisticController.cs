using Microsoft.AspNetCore.Mvc;
using Statistic.Di.Providers;
using Statistic.Service.Controllers.Dto;

namespace Statistic.Service.Controllers
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
