
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingleServiceApp.Controllers.Statistics.Dto
{
    public class StatisticWebModelCollection
    {
        public DateTime Date { get; set; }

        public IEnumerable<StatisticWebModel> Models { get; set; }
    }
}
