using Microsoft.EntityFrameworkCore;

using SingleServiceApp.Bll.Auth;
using SingleServiceApp.Bll.Statistics;
using SingleServiceApp.Controllers.Statistics.Dto;
using SingleServiceApp.Di.Statistics;
using SingleServiceApp.Providers.Auth;

using System.Linq;

namespace SingleServiceApp.Providers.Statistics
{
    internal class StatisticSqlProvider : IStatisticAsyncProvider
    {
        private readonly StatisticDbContext _context;
        private readonly AuthContext _authContext;

        public StatisticSqlProvider(AuthContext authContext)
        {
            _context = new StatisticDbContext();
            _authContext = authContext;
        }

        public async Task<IEnumerable<Statistic>> CreateStatistic(IEnumerable<StatisticCreationDto> data)
        {
            var range = data.Select(x => new Statistic(x, _authContext.GetUser()));
            await _context.AddRangeAsync(range);
            return range;
        }

        public async Task<IEnumerable<StatisticCollectionDto>> GetAllStatisticByTag(SearchParamsDto paramsDto)
        {
            var allStat = (await _context.Tags.FirstAsync(x =>
            x.Name.Equals(paramsDto.TagName)
            && x.User.Id == _authContext.GetUser().Id))
            .Statistics;
            var statFromTo = allStat.Where(x => x.Date >= paramsDto.From && x.Date <= paramsDto.To);

            if (paramsDto.TittleId is not null)
                statFromTo = statFromTo.Where(x => x.TitleId == paramsDto.TittleId);

            return StatisticMapper.StatisticMap(statFromTo);
        }

        public async Task<IEnumerable<Tag>> GetAllTags()
        {
            return await _context.Tags.AsNoTracking().ToListAsync();
        }
    }
}
