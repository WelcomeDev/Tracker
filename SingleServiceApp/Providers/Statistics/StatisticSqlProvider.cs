using Microsoft.EntityFrameworkCore;

using SingleServiceApp.Controllers.Statistics.Dto;
using SingleServiceApp.Di.Statistics;

using Statistic.Di;
using Statistic.Service.Controllers.Dto;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingleServiceApp.Providers.Statistics
{
    internal class StatisticSqlProvider : IStatisticAsyncProvider
    {
        private readonly StatisticDbContext _context;

        public StatisticSqlProvider(string connectionString)
        {
            _context = new StatisticDbContext(connectionString);
        }


        public async Task<IEnumerable<IStatistic>> CreateStatistic(IEnumerable<StatisticCreationDto> data)
        {
            var range = data.Select(x => new Entity.Statistic(x));
            await _context.AddRangeAsync(range);
            return range;
        }

        public async Task<IEnumerable<StatisticWebModelCollection>> GetAllStatisticByTag(SearchParamsDto paramsDto)
        {
            var AllStat = (await _context.Tags.FirstAsync(x => x.Id == paramsDto.TagId)).Statistics;
            var StatFromTo = AllStat.Where(x => x.Date >= paramsDto.From && x.Date <= paramsDto.To);

            if (paramsDto.TittleId is not null)
                return StatisticMapper.StatisticMap(StatFromTo.Where(x => x.TitleId == paramsDto.TittleId));

            return StatisticMapper.StatisticMap(StatFromTo);
        }
    }
}
