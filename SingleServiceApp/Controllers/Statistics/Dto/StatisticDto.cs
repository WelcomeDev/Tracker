using SingleServiceApp.Bll.Statistics;

namespace SingleServiceApp.Controllers.Statistics.Dto
{
    public class StatisticDto
    {
        public string Title { get; set; }
        public IList<double?> Value { get; set; }
        public string Color { get; set; }
    }
}
