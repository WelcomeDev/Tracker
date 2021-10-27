using System.ComponentModel.DataAnnotations;

using Statistic.Di.Tag;

using static Statistic.Bll.Provider.DbValidationConfig;

namespace Statistic.Bll.Provider.Entity
{
    internal class TagEntity : ITag
    {
        [Key]
        public Guid Id { get; set; }

        [MinLength(TitleMinLength)]
        [MaxLength(TitleMaxLength)]
        public string Title { get; set; }

        public virtual ICollection<StatisticEntity> Statistics { get; set; }

        public bool Equals(ITag other)
        {
            throw new NotImplementedException();
        }
    }
}
