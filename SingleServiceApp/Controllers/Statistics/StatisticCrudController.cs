using Microsoft.AspNetCore.Mvc;

using SingleServiceApp.Controllers.Statistics.Dto;
using SingleServiceApp.Di.Statistics;

namespace SingleServiceApp.Controllers.Statistics
{
    [ApiController]
    [Route("api/statistic")]
    public class StatisticCrudController : ControllerBase
    {
        private readonly IStatisticAsyncProvider _provider;

        public StatisticCrudController(IStatisticAsyncProvider provider)
        {
            _provider = provider;
        }

        [HttpPost]
        [Route("create")]
        [ProducesResponseType(201)]
        public async Task<IActionResult> Create([FromBody] IEnumerable<StatisticCreationDto> statisticData)
        {
            var statistics = await _provider.CreateStatistic(statisticData);

            return Ok(statistics);
        }
    }
}
