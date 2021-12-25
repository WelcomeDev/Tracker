using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Statistic.Di.Providers
{
    public interface IStatisticAsyncProvider 
    {
        Task<IStatistic> CreateStatistic(StatisticCreationDto data);

        Task<IEnumerable<IStatistic>> GetAllStatisticByTag(SearchParamsDto paramsDto);


    }
}
