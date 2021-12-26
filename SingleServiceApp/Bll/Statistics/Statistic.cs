using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using SingleServiceApp.Bll.Auth;
using SingleServiceApp.Controllers.Statistics.Dto;

namespace SingleServiceApp.Bll.Statistics
{
    public class Statistic
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public UserEntry User { get; set; }

        public Guid TagId { get; set; }
        public virtual Tag Tag { get; set; }

        public Guid TitleId { get; set; }
        public virtual Title Title { get; set; }

        public DateTime Date { get; set; }
        public double Value { get; set; }

        public Statistic()
        {

        }

        public Statistic(StatisticCreationDto statisticCreation, UserEntry user)
        {
            TagId = statisticCreation.TagId;
            TitleId = statisticCreation.TitleId;
            Value = statisticCreation.Value;
            User = user;
        }
    }
}
