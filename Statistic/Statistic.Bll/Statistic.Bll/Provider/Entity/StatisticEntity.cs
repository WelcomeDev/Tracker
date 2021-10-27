using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using static Statistic.Bll.Provider.DbValidationConfig;

using Auth.Di;

using Statistic.Di;
using Statistic.Di.Tag;
using System.Diagnostics.CodeAnalysis;

namespace Statistic.Bll.Provider.Entity
{
    internal class StatisticEntity : IStatisticData
    {
        public Guid Id { get; set; }

        public UserIdentity User { get; }

        public int TagId { get; set; }

        [NotNull]
        public virtual TagEntity Tag { get; set; }

        [MinLength(TitleMinLength)]
        [MaxLength(TitleMaxLength)]
        public string Title { get; set; }

        public DateTime Date { get; set; }

        [Range(StatValueMin, StatValueMax)]
        public double Value { get; set; }

        [NotMapped]
        ITag IStatisticData.Tag
        {
            get => Tag;
            set
            {
                Tag = value as TagEntity;
            }
        }

        [NotMapped]
        IUserIdentity IStatisticData.User
        {
            get => User;
        }
    }
}
