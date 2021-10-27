using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

using Statistic.Bll.Provider.Entity;

namespace Statistic.Bll
{
    internal class StatisticDbContext : DbContext
    {
        //public DbSet<TagEntity> Tags { get; set; }

        public DbSet<StatisticEntity> Statistics { get; set; }

        public StatisticDbContext()
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<TagEntity>()
                        .Property(x => x.Id)
                        .HasDefaultValueSql("NEWID()");

            modelBuilder.Entity<StatisticEntity>()
                       .Property(x => x.Id)
                       .HasDefaultValueSql("NEWID()");

            modelBuilder.Entity<StatisticEntity>()
                       .Property(x => x.Date)
                       .HasDefaultValueSql("GETDATE()");
        }
    }
}
