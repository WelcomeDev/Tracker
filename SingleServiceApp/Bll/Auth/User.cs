using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SingleServiceApp.Bll.Auth
{
    public class User
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        public string Login { get; set; }    

        public string Password { get; set; }

        public string Role { get; set; }    
    }
}
