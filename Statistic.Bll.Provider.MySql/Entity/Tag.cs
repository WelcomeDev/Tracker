using Auth.Di;
using Statistic.Di.Tag;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Statistic.Bll.Provider.MySql.Entity
{
    public class Tag : ITagData
    {
        public Tag()
        {
            Tittles = new HashSet<Title>();
        }

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(20)]
        public string Name { get; set; }

        [Required]
        public Guid UserId { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; }

        public double? MaxValue { get; set; }

        public virtual ICollection<Title> Tittles { get; set; }

        IUserIdentity ITagData.User => User;
    }
}
