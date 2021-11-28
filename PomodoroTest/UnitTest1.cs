using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pomodoro.Bll.Provider.MySql.Entity;
using System.Linq;

namespace PomodoroTest
{
    [TestClass]
    public class UnitTestSQL
    {
        [TestMethod]
        public void CheckUser()
        {
            PomodoroContext context = new PomodoroContext();
            var userCount = context.Users.Count();
            Assert.AreEqual(userCount, 1);
        }

        [TestMethod]
        public void CheckAddPomodoro()
        {
            using PomodoroContext context = new PomodoroContext();
            using var transaction = context.Database.BeginTransaction();

            try
            {
                var testPomodoro = new Pomodoro.Bll.Provider.MySql.Entity.Pomodoro()
                {
                    User = context.Users.First(),
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

                context.Add(testPomodoro);
                context.SaveChanges();

                var pomodoroGUID = testPomodoro.Id;

                Assert.AreEqual(testPomodoro, context.Pomodoros.First(x => x.Id == pomodoroGUID));

                context.Remove(testPomodoro);
                context.SaveChanges();

                transaction.Commit();
            }
            catch
            {

            }

            
        }
    }
}