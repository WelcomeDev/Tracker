using System.ComponentModel.DataAnnotations;
using SingleServiceApp.Bll.Auth;

namespace SingleServiceApp.Bll.Statistics
{
    public class Tag : IEquatable<Tag>
    {
        [Key]
        public string Name { get; set; }

        public UserEntry User { get; set; }

        public double? MaxValue { get; set; }

        public virtual ICollection<Title> Tittles { get; set; }

        public virtual ICollection<Statistic> Statistics { get; set; }

        public bool Equals(Tag other)
        {
            if (other is null) return false;

            return Name.Equals(other.Name);
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as Tag);
        }
    }
}
