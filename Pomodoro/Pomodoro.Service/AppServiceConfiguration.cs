using Microsoft.AspNetCore.Mvc;
using WelcomeDev.Utils.Json.Newtonsoft;

using Newtonsoft.Json.Serialization;
using Newtonsoft.Json.Converters;

using Pomodoro.Bll.Provider.MySql;
using Pomodoro.Di.Duration;
using Pomodoro.Di.Provider;
using Pomodoro.Service.Controllers.Dto;
using Pomodoro.Service.Providers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Pomodoro.Service.Controllers.Actions.Validation;

namespace Pomodoro.Service
{
    public static class AppServiceConfiguration
    {
        public static void RegisterValidationServices(WebApplicationBuilder builder)
        {
            builder.Services.AddSingleton<IPomodoroValidation, TitleValidation>();
            builder.Services.AddSingleton<IPomodoroValidation, RestDurationValidation>();
            builder.Services.AddSingleton<IPomodoroValidation, WorkDurationValidation>();
        }

        public static void RegisterProviders(WebApplicationBuilder builder)
        {
            IConfiguration configuration = builder.Configuration;

            //builder.Services.AddDbContext<PomodoroDbContext>(
            //    options => options.UseSqlServer(configuration.GetConnectionString("PomodoroDb"))
            //    );
            builder.Services.AddSingleton<IPomodoroAsyncProvider, PomodoroSqlProvider>(
                options => new PomodoroSqlProvider(configuration.GetConnectionString("PomodoroDb"))
                );
            builder.Services.AddSingleton<PomodoroProvider>();
        }

        public static void ConfigureNewtonsoftJson(MvcNewtonsoftJsonOptions options)
        {
            options.SerializerSettings.Converters.Add(new StringEnumConverter());
            options.SerializerSettings.ContractResolver = new DefaultContractResolver()
            {
                NamingStrategy = new CamelCaseNamingStrategy(),
            };
            options.SerializerSettings.Converters.Add(new JsonTypeMapper<IDuration, DurationDto>());
        }
    }
}
