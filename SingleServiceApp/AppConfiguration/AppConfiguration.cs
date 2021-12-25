namespace SingleServiceApp.AppConfiguration
{
    public static class AppConfiguration
    {
        private static readonly IWebAppConfig[] _configs = new IWebAppConfig[]
        {
            new GeneralConfig(),
            new PomodoroConfiguration(),
            new StatisticsConfiguration(),
        };

        public static void ConfigureApp(this WebApplicationBuilder builder)
        {
            Array.ForEach(_configs, config => config.Config(builder));
        }
    }
}
