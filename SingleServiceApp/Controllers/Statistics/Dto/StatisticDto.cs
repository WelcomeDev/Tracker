using Auth.Di;

using Statistic.Di;
using Statistic.Di.Tag;
using Statistic.Di.Tittle;

namespace SingleServiceApp.Controllers.Statistics.Dto
{
    public class StatisticDto
    {

        public ITitle Title { get; set; }

        public double Value { get; set; }

    }
}
