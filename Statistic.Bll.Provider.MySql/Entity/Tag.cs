using Auth.Di;
using Statistic.Di.Tag;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Statistic.Bll.Provider.MySql.Entity
{
    public class Tag : ITag
    {
        public Tag()
        {
            Tittles = new HashSet<Title>();
            Statistics = new HashSet<Statistic>();
        }

        public Tag(ITag data)
        {
            Id = data.Id;
            Name = data.Name;
            MaxValue = data.MaxValue;
            User = new User(data.User);
        }

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(20)]
        public string Name { get; set; }

        [Required]
        public User User { get; set; }

        public double? MaxValue { get; set; }

        public virtual ICollection<Title> Tittles { get; set; }

        public virtual ICollection<Statistic> Statistics { get; set; }

        IUserIdentity ITag.User => User;
    }
}
