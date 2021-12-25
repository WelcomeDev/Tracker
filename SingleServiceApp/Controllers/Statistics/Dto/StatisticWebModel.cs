using Statistic.Di.Tittle;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingleServiceApp.Controllers.Statistics.Dto
{
    public class StatisticWebModel
    {
        public StatisticWebModel(IStatistic statistic)
        {
            Title = statistic.Title;
            Value = statistic.Value;
            Color = $"#{Title.ColorSql.R:X2}{Title.ColorSql.G:X2}{Title.ColorSql.B:X2}";
        }

        public ITitle Title { get; set; }
        public double Value { get; set; }
        public string Color { get; set; }
    }
}
