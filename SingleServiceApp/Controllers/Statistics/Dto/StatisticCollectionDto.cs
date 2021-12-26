
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingleServiceApp.Controllers.Statistics.Dto
{
    public class StatisticCollectionDto
    {
        public IEnumerable<DateTime> Dates { get; set; }

        public IEnumerable<StatisticDto> Models { get; set; }
    }
}
