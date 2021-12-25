
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;

namespace SingleServiceApp.Bll.Statistics
{
    public class Title : IEquatable<Title>
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        public string Name { get; set; }

        public Tag Tag { get; set; }

        public Color Color { get; set; }

        public bool Equals(Title other)
        {
            if (other is null)
                return false;

            return Name.Equals(other.Name);
        }
    }
}
