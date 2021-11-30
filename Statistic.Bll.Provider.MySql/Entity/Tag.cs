using Auth.Di;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Statistic.Bll.Provider.MySql.Entity
{
    public class Tag
    {
        public Tag()
        {
            Tittles = new HashSet<Tittle>();
        }

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(20)]
        public string Subject { get; set; }

        [Required]
        public Guid UserId { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; }

        public double? MaxValue { get; set; }

        public virtual ICollection<Tittle> Tittles { get; set; }
    }
}
