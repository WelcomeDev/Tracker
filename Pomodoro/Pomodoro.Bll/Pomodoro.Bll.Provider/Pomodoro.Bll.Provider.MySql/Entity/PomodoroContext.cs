using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pomodoro.Bll.Provider.MySql.Entity
{
    public class PomodoroContext : DbContext
    {
        public DbSet<Pomodoro> Pomodoros { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=pomodorodb;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pomodoro>().OwnsOne(x => x.RestDuration, restDuration =>
            {
                restDuration.Property(x => x.Hours).HasColumnName("RestHours");
                restDuration.Property(x => x.Minutes).HasColumnName("RestMinutes");
            });

            modelBuilder.Entity<Pomodoro>().OwnsOne(x => x.WorkDuration, workDuration =>
            {
                workDuration.Property(x => x.Hours).HasColumnName("WorkHours");
                workDuration.Property(x => x.Minutes).HasColumnName("WorkMinutes");
            });
        }
    }
}
