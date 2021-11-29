using Microsoft.VisualStudio.TestTools.UnitTesting;

using Pomodoro.Bll.Provider.MySql;
using Pomodoro.Bll.Provider.MySql.Entity;

using System.Linq;

namespace PomodoroTest
{
    [TestClass]
    public class UnitTestSQL
    {
        PomodoroDbContext _context;
        private const string DbConnection = "Server=(localdb)\\mssqllocaldb;Database=pomodorodb_test;Trusted_Connection=True;MultipleActiveResultSets=true";

        [TestInitialize]
        public void Setup()
        {
            _context = new PomodoroDbContext(DbConnection);
        }

        [TestMethod]
        public void CheckUser()
        {
            var userCount = _context.Users.Count();
            Assert.AreEqual(userCount, 1);
        }

        [TestMethod]
        public void CheckAddPomodoro()
        {
            using var transaction = _context.Database.BeginTransaction();

            try
            {
                var testPomodoro = new Pomodoro.Bll.Provider.MySql.Entity.Pomodoro()
                {
                    User = _context.Users.First(),
                    RestDuration = new Duration()
                    {
                        Hours = 0,
                        Minutes = 10
                    },
                    WorkDuration = new Duration()
                    {
                        Hours = 0,
                        Minutes = 30
                    },
                    Title = "testPomodoro2"
                };

                _context.Add(testPomodoro);
                _context.SaveChanges();

                var pomodoroGUID = testPomodoro.Id;

                Assert.AreEqual(testPomodoro, _context.Pomodoros.First(x => x.Id == pomodoroGUID));

                _context.Remove(testPomodoro);
                _context.SaveChanges();

                transaction.Commit();
            }
            catch
            {

            }

            
        }
    }
}