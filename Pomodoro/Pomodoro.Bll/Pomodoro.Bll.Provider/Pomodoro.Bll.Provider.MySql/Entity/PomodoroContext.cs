using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pomodoro.Bll.Provider.MySql.Entity
{
    internal class PomodoroContext : DbContext
    {
        public DbSet<Pomodoro> Pomodoros { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=pomodorodb;Trusted_Connection=True;");
        }
    }
}
