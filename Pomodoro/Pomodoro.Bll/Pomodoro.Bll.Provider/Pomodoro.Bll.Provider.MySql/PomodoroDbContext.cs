using Microsoft.EntityFrameworkCore;

using Pomodoro.Bll.Provider.MySql.Entity;

namespace Pomodoro.Bll.Provider.MySql
{
    public class PomodoroDbContext : DbContext
    {
        private readonly string _connectionString;
        public DbSet<Entity.Pomodoro> Pomodoros { get; set; }
        public DbSet<User> Users { get; set; }

        public PomodoroDbContext()
        {
            _connectionString = "Server=(localdb)\\mssqllocaldb;Database=pomodorodb;Trusted_Connection=True;MultipleActiveResultSets=true";
        }

        public PomodoroDbContext(DbContextOptions options) : base(options)
        {
        }

        public PomodoroDbContext(string connectionString)
        {
            _connectionString = connectionString;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Entity.Pomodoro>().OwnsOne(x => x.RestDuration, restDuration =>
            {
                restDuration.Property(x => x.Hours).HasColumnName("RestHours");
                restDuration.Property(x => x.Minutes).HasColumnName("RestMinutes");
            });

            modelBuilder.Entity<Entity.Pomodoro>().OwnsOne(x => x.WorkDuration, workDuration =>
            {
                workDuration.Property(x => x.Hours).HasColumnName("WorkHours");
                workDuration.Property(x => x.Minutes).HasColumnName("WorkMinutes");
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
