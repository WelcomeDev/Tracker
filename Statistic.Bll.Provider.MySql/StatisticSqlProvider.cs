using Microsoft.EntityFrameworkCore;
using Statistic.Di;
using Statistic.Di.Providers;
using Statistic.Service.Controllers.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Statistic.Bll.Provider.MySql
{
    internal class StatisticSqlProvider : IStatisticAsyncProvider
    {
        private readonly StatisticDbContext _context;

        public StatisticSqlProvider(string connectionString)
        {
            _context = new StatisticDbContext(connectionString);
        }

        public async Task<IStatistic> CreateStatistic(IStatistic data)
        {
            var stat = await _context.AddAsync(new Entity.Statistic(data));
            return stat.Entity;
        }

        public async Task<IEnumerable<IStatistic>> GetAllStatisticByTag(SearchParamsDto paramsDto)
        {
            var AllStat = (await _context.Tags.FirstAsync(x => x.Id == paramsDto.TagId)).Statistics;
            var StatFromTo = AllStat.Where(x => x.Date >= paramsDto.From && x.Date <= paramsDto.To);

            if (paramsDto.TittleId is not null)
                return StatFromTo.Where(x => x.TitleId == paramsDto.TittleId);

            return StatFromTo;

        }
    }
}
