using SingleServiceApp.Bll.Statistics;

namespace SingleServiceApp.Controllers.Statistics.Dto
{
    public class StatisticDto
    {
        public StatisticDto(Statistic statistic)
        {
            Title = statistic.Title;
            Value = statistic.Value;
            Color = $"#{Title.ColorSql.Color.R:X2}{Title.ColorSql.Color.G:X2}{Title.ColorSql.B:X2}";
        }

        public Title Title { get; set; }
        public double Value { get; set; }
        public string Color { get; set; }
    }
}
