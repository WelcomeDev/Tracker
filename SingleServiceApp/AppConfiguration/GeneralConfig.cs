using Microsoft.AspNetCore.Mvc;

using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

namespace SingleServiceApp.AppConfiguration
{
    public class GeneralConfig : IWebAppConfig
    {
        public void Config(WebApplicationBuilder builder)
        {
            builder.Services.AddControllers()
               .AddNewtonsoftJson(
               options => ConfigureNewtonsoftJson(options)
               );
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddCors(options =>
            {
                options.AddDefaultPolicy(builder =>
                {
                    builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
                });
            });
        }

        private static void ConfigureNewtonsoftJson(MvcNewtonsoftJsonOptions options)
        {
            options.SerializerSettings.Converters.Add(new StringEnumConverter());
            options.SerializerSettings.ContractResolver = new DefaultContractResolver()
            {
                NamingStrategy = new CamelCaseNamingStrategy(),
            };
            // TODO: resolve
            //options.SerializerSettings.Converters.Add(new JsonTypeMapper<IDuration, DurationDto>());
        }
    }
}
