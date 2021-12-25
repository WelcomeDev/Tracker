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
            IConfiguration configuration = builder.Configuration;

            //builder.Services.AddDbContext<PomodoroDbContext>(
            //    options => options.UseSqlServer(configuration.GetConnectionString("PomodoroDb"))
            //    );
            // TODO: resolve
            //builder.Services.AddSingleton<IPomodoroAsyncProvider, PomodoroSqlProvider>(
            //    options => new PomodoroSqlProvider(configuration.GetConnectionString("PomodoroDb"))
            //    );
            builder.Services.AddSingleton<PomodoroProvider>();
        }
    }
}
