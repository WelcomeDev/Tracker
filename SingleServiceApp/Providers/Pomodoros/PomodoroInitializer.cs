using SingleServiceApp.Bll.Pomodoros;
using SingleServiceApp.Providers.Auth;

namespace SingleServiceApp.Providers.Pomodoros
{
    public static class PomodoroInitializer
    {
        public static void Initialize(PomodoroDbContext context, AuthContext auth)
        {

            context.AddRange(new[]
            {
                new Pomodoro
                {
                    Title = "Test1",

                    RestDuration = new Duration
                    {
                        Hours = 0,
                        Minutes = 15
                    },

                    WorkDuration = new Duration
                    {
                        Hours = 0,
                        Minutes = 15
                    },

                    User = auth.GetCurrentUser()
                },

                new Pomodoro
                {
                    Title = "Test2",

                    RestDuration = new Duration
                    {
                        Hours = 0,
                        Minutes = 20
                    },

                    WorkDuration = new Duration
                    {
                        Hours = 0,
                        Minutes = 40
                    },

                    User = auth.GetCurrentUser()
                },

                new Pomodoro
                {
                    Title = "Test3",

                    RestDuration = new Duration
                    {
                        Hours = 0,
                        Minutes = 15
                    },

                    WorkDuration = new Duration
                    {
                        Hours = 0,
                        Minutes = 45
                    },

                    User = auth.GetCurrentUser()
                },
            });
            context.SaveChanges();
        }
    }
}
