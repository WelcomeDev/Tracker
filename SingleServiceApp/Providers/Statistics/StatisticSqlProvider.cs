using Microsoft.EntityFrameworkCore;

using SingleServiceApp.Bll.Statistics;
using SingleServiceApp.Controllers.Statistics.Dto;
using SingleServiceApp.Di.Statistics;
using SingleServiceApp.Providers.Auth;

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
            if (_context.Tags.Count() == 0)
                StatisticInitializer.Initialize(_context, _authContext);
        }

        public async Task<IEnumerable<Statistic>> CreateStatistic(IEnumerable<StatisticCreationDto> data)
        {
            var range = data.Select(x => new Statistic(x, _authContext.GetCurrentUser()));
            await _context.AddRangeAsync(range);
            return range;
        }

        public async Task<IEnumerable<StatisticCollectionDto>> GetAllStatisticByTag(SearchParamsDto paramsDto)
        {
            var allStat = (await _context.Tags.FirstAsync(x =>
            x.Name.Equals(paramsDto.TagName)
            && x.User.Id == _authContext.GetCurrentUser().Id))
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
