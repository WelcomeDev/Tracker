using System.ComponentModel.DataAnnotations.Schema;

namespace SingleServiceApp.Bll.Auth
{
    [ComplexType]
    public class UserEntry
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
