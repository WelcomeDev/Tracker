using AutoMapper;

using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

using SingleServiceApp.Bll.Pomodoros;
using SingleServiceApp.Controllers.Auth.Actions;
using SingleServiceApp.Controllers.Pomodoro.Dto;
using SingleServiceApp.Controllers.Pomodoro.Validation;
using SingleServiceApp.Di.Auth;
using SingleServiceApp.Providers.Auth;

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
            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.RequireHttpsMetadata = false;
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        // укзывает, будет ли валидироваться издатель при валидации токена
                        ValidateIssuer = true,
                        // строка, представляющая издателя
                        ValidIssuer = AuthOptions.Issuer,
                        // будет ли валидироваться потребитель токена
                        ValidateAudience = true,
                        // установка потребителя токена
                        ValidAudience = AuthOptions.Audience,
                        // будет ли валидироваться время существования
                        ValidateLifetime = true,

                        // установка ключа безопасности
                        IssuerSigningKey = AuthOptions.GetSymmetricSecurityKey(),
                        // валидация ключа безопасности
                        ValidateIssuerSigningKey = true,
                    };
                });

            builder.Services.AddHttpContextAccessor();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddAutoMapper(config => ConfigureMapper(config));

            builder.Services.AddCors(options =>
            {
                options.AddDefaultPolicy(builder =>
                {
                    builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
                });
            });

            ConfigureAuth(builder);
        }

        private static void ConfigureAuth(WebApplicationBuilder builder)
        {
            
            builder.Services.AddSingleton<AuthContext>();
            builder.Services.AddSingleton<IAuthAsyncProvider, AuthSqlProvider>();
            builder.Services.AddSingleton<AuthActions>();
        }

        private static void ConfigureMapper(IMapperConfigurationExpression config)
        {
            config.CreateMap<CreatePomodoroDto, ValidationParams>();
            config.CreateMap<UpdatePomodoroDto, ValidationParams>();
            config.CreateMap<Pomodoro, PomodoroDto>();
        }

        private static void ConfigureNewtonsoftJson(MvcNewtonsoftJsonOptions options)
        {
            options.SerializerSettings.Converters.Add(new StringEnumConverter());
            options.SerializerSettings.ContractResolver = new DefaultContractResolver()
            {
                NamingStrategy = new CamelCaseNamingStrategy(),
            };
        }
    }
}
