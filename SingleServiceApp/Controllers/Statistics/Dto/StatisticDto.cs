using SingleServiceApp.Bll.Statistics;

namespace SingleServiceApp.Controllers.Statistics.Dto
{
    public class StatisticDto
    {
        public StatisticDto(Statistic statistic)
        {
            var title = statistic.Title;

            TitleId = title.Id;
            Value = statistic.Value;
            Color = $"#{title.ColorSql.Color.R:X2}{title.ColorSql.Color.G:X2}{title.ColorSql.Color.B:X2}";
        }

        public Guid TitleId { get; set; }
        public double Value { get; set; }
        public string Color { get; set; }
    }
}
