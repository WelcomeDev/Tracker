using AutoMapper;

using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

using SingleServiceApp.Bll.Auth;
using SingleServiceApp.Bll.Pomodoros;
using SingleServiceApp.Bll.Statistics;
using SingleServiceApp.Controllers.Auth.Actions;
using SingleServiceApp.Controllers.Pomodoro.Dto;
using SingleServiceApp.Controllers.Pomodoro.Validation;
using SingleServiceApp.Controllers.Statistics.Dto;
using SingleServiceApp.Di.Auth;
using SingleServiceApp.Providers.Auth;
using SingleServiceApp.Providers.Statistics.Arguments;

namespace SingleServiceApp.AppConfiguration
{
    public class GeneralConfig : IWebAppConfig
    {
        public void Config(WebApplicationBuilder builder)
        {
            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.RequireHttpsMetadata = true;
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        //// укзывает, будет ли валидироваться издатель при валидации токена
                        //ValidateIssuer = false,
                        //// строка, представляющая издателя
                        //ValidIssuer = AuthOptions.Issuer,
                        // будет ли валидироваться время существования
                        //ValidateLifetime = true,

                        // установка ключа безопасности
                        IssuerSigningKey = AuthOptions.GetSymmetricSecurityKey(),
                        // валидация ключа безопасности
                        ValidateIssuerSigningKey = true,
                    };
                });

            builder.Services.AddControllers()
                .AddNewtonsoftJson(
                options => ConfigureNewtonsoftJson(options)
                );
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
            config.CreateMap<Tag, TagDto>();
            config.CreateMap<Title, TitleDto>()
                  .ForMember(dest => dest.Color, opt => opt.MapFrom(src =>
                  $"#{src.ColorSql.Color.R:X2}{src.ColorSql.Color.G:X2}{src.ColorSql.Color.B:X2}"));
            config.CreateMap<Statistic, StatisticDto>();
            config.CreateMap<SearchParamsDto, StatisticSearchArguments>()
                .ForMember(dest => dest.From,
                opt => opt.MapFrom(src => DateTime.ParseExact(src.From, "yyyy-MM-dd", null)))
                .ForMember(dest => dest.To,
                opt => opt.MapFrom(src => DateTime.ParseExact(src.To, "yyyy-MM-dd", null)));
        }

        private static void ConfigureNewtonsoftJson(MvcNewtonsoftJsonOptions options)
        {
            options.SerializerSettings.Converters.Add(new StringEnumConverter());
            options.SerializerSettings.ContractResolver = new DefaultContractResolver()
            {
                NamingStrategy = new CamelCaseNamingStrategy(),
            };
            options.SerializerSettings.DateFormatString = "yyyy-MM-dd";
        }
    }
}
