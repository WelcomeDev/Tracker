using SingleServiceApp.Controllers.Pomodoro.Validation;
using SingleServiceApp.Di.Pomodoros;
using SingleServiceApp.Providers.Pomodoros;

namespace SingleServiceApp.AppConfiguration
{
    public class PomodoroConfiguration : IWebAppConfig
    {
        public void Config(WebApplicationBuilder builder)
        {
            RegisterValidationServices(builder);
            RegisterProviders(builder);
        }

        private static void RegisterValidationServices(WebApplicationBuilder builder)
        {
            builder.Services.AddSingleton<IPomodoroValidation, TitleValidation>();
            builder.Services.AddSingleton<IPomodoroValidation, RestDurationValidation>();
            builder.Services.AddSingleton<IPomodoroValidation, WorkDurationValidation>();
        }

        private static void RegisterProviders(WebApplicationBuilder builder)
        {
            builder.Services.AddSingleton<PomodoroProvider>();
            builder.Services.AddSingleton<IPomodoroAsyncProvider, PomodoroSqlProvider>();
        }
    }
}
