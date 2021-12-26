
using Microsoft.EntityFrameworkCore;

using SingleServiceApp.Bll.Auth;

namespace SingleServiceApp.Providers.Auth
{
    public class AuthDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=tracker_users;Trusted_Connection=True;MultipleActiveResultSets=true");
        }
    }
}
