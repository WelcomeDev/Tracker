
using Microsoft.EntityFrameworkCore;

using SingleServiceApp.Bll.Auth;

namespace SingleServiceApp.Providers.Auth
{
    internal class UsersDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public UsersDbContext(DbContextOptions<UsersDbContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=tracker_users;Trusted_Connection=True;MultipleActiveResultSets=true");
        }
    }
}
