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

        public bool Equals(Tag other)
        {
            if (other is null) return false;

            return Name.Equals(other.Name);
        }
    }
}
