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
    public class Statistic : IStatisticData
    {
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
        public Guid TittleId { get; set; }

        [ForeignKey("TittleId")]
        public Title Title { get; set; }

        [Required]
        public Guid UserId { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; }

        ITitleData IStatisticData.Title => Title;

        IUserIdentity IStatisticData.User => User;

        ITagData IStatisticData.Tag => Tag;
    }
}
