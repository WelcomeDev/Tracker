using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pomodoro.Bll.Provider.MySql.Entity
{
    internal class Pomodoro
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [MaxLength(20)]
        [Required]
        public string Title { get; set; }

        [Required]
        public Duration RestDuration { get; set; }

        [Required]
        public Duration WorkDuration { get; set; }

        [Required]
        public Guid UserId { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; }
    }
}
