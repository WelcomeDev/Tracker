
using SingleServiceApp.Providers.Statistics.Entity;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SingleServiceApp.Bll.Statistics
{
    public sealed class Title : IEquatable<Title>
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        public string Name { get; set; }

        public Guid TagId { get; set; }

        public Tag Tag { get; set; }

        public Guid ColorId { get; set; }

        [ForeignKey("ColorId")]
        [Column("Color")]
        public ColorSql ColorSql { get; set; }

        public bool Equals(Title other)
        {
            if (other is null)
                return false;

            return Name.Equals(other.Name);
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as Title);
        }
    }
}
