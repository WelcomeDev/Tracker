using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Statistic.Di.Providers
{
    public interface IStatisticAsyncProvider 
    {
        Task<IEnumerable<IStatistic>> CreateStatistic(IEnumerable<StatisticCreationDto> data);

        Task<IEnumerable<StatisticWebModelCollection>> GetAllStatisticByTag(SearchParamsDto paramsDto);


    }
}
