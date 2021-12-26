using System.ComponentModel.DataAnnotations;

namespace SingleServiceApp.Providers.Statistics.Arguments
{
    public class StatisticSearchArguments
    {
        public string TagName { get; set; }

        public DateTime From { get; set; }

        public DateTime To { get; set; }
    }
}
