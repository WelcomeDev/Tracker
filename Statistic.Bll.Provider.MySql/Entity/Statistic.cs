using Auth.Di;
using Statistic.Di;
using Statistic.Di.Tag;
using Statistic.Di.Tittle;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Statistic.Bll.Provider.MySql.Entity
{
    public class Statistic : IStatistic
    {
        public Statistic(IStatistic data)
        {
            Id = data.Id;
            Date = data.Date;
            Value = data.Value;
            TagId = Tag.Id;
            TitleId = Title.Id;
            User.Id = User.Id;

        }

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public double Value { get; set; }

        [Required]
        public Guid TagId { get; set; }

        [ForeignKey("TagId")]
        public Tag Tag { get; set; }

        [Required]
        public Guid TitleId { get; set; }

        [ForeignKey("TittleId")]
        public Title Title { get; set; }

        [Required]
        public Guid UserId { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; }

        ITitle IStatistic.Title => Title;

        IUserIdentity IStatistic.User => User;

        ITag IStatistic.Tag => Tag;
    }
}
