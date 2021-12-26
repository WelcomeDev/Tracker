using AutoMapper;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using SingleServiceApp.Controllers.Authorization;
using SingleServiceApp.Controllers.Statistics.Dto;
using SingleServiceApp.Di.Statistics;
using SingleServiceApp.Providers.Statistics.Arguments;

namespace SingleServiceApp.Controllers.Statistics
{
    [ApiController]
    [Route("api/statistic")]
    [Authorized]
    public class StatisticCrudController : ControllerBase
    {
        private readonly IStatisticAsyncProvider _provider;
        private readonly IMapper _mapper;

        public StatisticCrudController(IStatisticAsyncProvider provider, IMapper mapper)
        {
            _provider = provider;
            _mapper = mapper;
        }

        [HttpPost]
        [Route("create")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> Create([FromBody] IEnumerable<StatisticCreationDto> statisticData)
        {
            var statistics = await _provider.CreateStatistic(statisticData);

            return Ok(statistics);
        }

        [HttpGet]
        [Route("list")]
        public async Task<IActionResult> List([FromQuery] SearchParamsDto paramsDto)
        {
            var arguments = _mapper.Map<StatisticSearchArguments>(paramsDto);
            var pomodoro = await _provider.GetAllStatisticByTag(arguments);

            return Ok(pomodoro);
        }

        [HttpGet]
        [Route("tags/list")]
        public async Task<IActionResult> ListTags()
        {
            var tags = await _provider.GetAllTags();
            var dto = tags.Select(t => _mapper.Map<TagDto>(t));

            return Ok(dto);
        }

        [HttpGet]
        [Route("titles/list")]
        public async Task<IActionResult> ListTitles([FromQuery] string tagName)
        {
            var tags = await _provider.GetAllTitlesByTag(tagName);
            var dto = tags.Select(t => _mapper.Map<TitleDto>(t));

            return Ok(dto);
        }
    }
}
