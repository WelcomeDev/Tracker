using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pomodoro.Bll.Provider.MySql.Entity;
using System.Linq;

namespace PomodoroTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            PomodoroContext context = new PomodoroContext();
            context.Add(new User()
            {
                Id = new System.Guid(),
                Name = "tester"
            });
            context.SaveChanges();
            var userCount = context.Users.Count();
            Assert.AreEqual(userCount, 1);
        }
    }
}