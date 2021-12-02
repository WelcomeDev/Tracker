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
    public class Title : ITitleData
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [Required, MaxLength(20)]
        public string Name { get; set; }

        [Required]
        public Guid TagId { get; set; }

        [ForeignKey("TagId")]
        public Tag Tag { get; set; }

        [Required]
        public Guid ColorId { get; set; }

        [ForeignKey("ColorId")]
        public ColorSql Color { get; set; }


        ITagData ITitleData.Tag => Tag;
    }
}
