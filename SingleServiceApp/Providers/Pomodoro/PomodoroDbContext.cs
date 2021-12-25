using Microsoft.EntityFrameworkCore;

namespace SingleServiceApp.Providers.Pomodoro
{
    public class PomodoroDbContext : DbContext
    {
        public DbSet<Entity.Pomodoro> Pomodoros { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=pomodorodb;Trusted_Connection=True;MultipleActiveResultSets=true");
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
