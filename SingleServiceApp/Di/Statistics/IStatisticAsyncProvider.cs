using SingleServiceApp.Controllers.Statistics.Dto;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingleServiceApp.Di.Statistics
{
    public interface IStatisticAsyncProvider
    {
        Task<IEnumerable<IStatistic>> CreateStatistic(IEnumerable<StatisticCreationDto> data);

        Task<IEnumerable<StatisticWebModelCollection>> GetAllStatisticByTag(SearchParamsDto paramsDto);


    }
}
