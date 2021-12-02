using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Statistic.Bll.Provider.MySql
{
    internal class StatisticDbContext : DbContext
    {
        private readonly string _connectionString;

        public DbSet<Entity.Tag> Tags { get; set; }

        public DbSet<Entity.Title> Title { get; set; }

        public DbSet<Entity.ColorSql> Colors { get; set; }

        public DbSet<Entity.Statistic> Statistics { get; set; }

        public StatisticDbContext()
        {
            _connectionString = "Server=(localdb)\\mssqllocaldb;Database=statisticdb;Trusted_Connection=True;MultipleActiveResultSets=true";
        }

        public StatisticDbContext(string connectionString)
        {
            _connectionString = connectionString;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<Entity.Statistic>()
                       .Property(x => x.Date)
                       .HasDefaultValueSql("GETDATE()");

            modelBuilder.Entity<Entity.Statistic>()
                .HasOne(x => x.Tag)
                .WithMany(x => x.Statistics)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Entity.Tag>().OwnsOne(x => x.User);
            modelBuilder.Entity<Entity.Statistic>().OwnsOne(x => x.User);
        }
    }
}
