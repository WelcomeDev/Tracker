
using SingleServiceApp.Di.Statistics;
using SingleServiceApp.Providers.Statistics;

namespace SingleServiceApp.AppConfiguration
{
    public class StatisticsConfiguration : IWebAppConfig
    {
        public void Config(WebApplicationBuilder builder)
        {
            RegisterProviders(builder);
        }

        private static void RegisterProviders(WebApplicationBuilder builder)
        {
            builder.Services.AddSingleton<IStatisticAsyncProvider, StatisticSqlProvider>();
        }
    }
}
