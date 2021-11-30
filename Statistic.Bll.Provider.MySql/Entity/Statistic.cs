using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Statistic.Bll.Provider.MySql.Entity
{
    public class Statistic
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
        public Tittle Tittle { get; set; }
    }
}
