using Microsoft.EntityFrameworkCore;

using SingleServiceApp.Bll.Statistics;
using SingleServiceApp.Providers.Statistics.Entity;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingleServiceApp.Providers.Statistics
{
    internal class StatisticDbContext : DbContext
    {
        public DbSet<Tag> Tags { get; set; }

        public DbSet<Title> Title { get; set; }

        public DbSet<ColorSql> Colors { get; set; }

        public DbSet<Statistic> Statistics { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=statisticdb;Trusted_Connection=True;MultipleActiveResultSets=true");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<Statistic>()
                       .Property(x => x.Date)
                       .HasDefaultValueSql("GETDATE()");

            modelBuilder.Entity<Statistic>()
                .HasOne(x => x.Tag)
                .WithMany(x => x.Statistics)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Tag>().OwnsOne(x => x.User);
            modelBuilder.Entity<Statistic>().OwnsOne(x => x.User);
        }
    }
}
