using Auth.Di;

using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

using Pomodoro.Bll;
using Pomodoro.Bll.Provider.Mock;
using Pomodoro.Di;
using Pomodoro.Di.Duration;
using Pomodoro.Di.Provider;
using Pomodoro.Service.Controllers.Actions;
using Pomodoro.Service.Controllers.Dto;
using Pomodoro.Service.MockUser;
using Pomodoro.Service.Providers;

using WelcomeDev.Utils.Json.Newtonsoft;

var builder = WebApplication.CreateBuilder(args);

static void RegisterValidationServices(WebApplicationBuilder builder)
{
    builder.Services.AddSingleton<IPomodoroValidation, TitleValidation>();
    builder.Services.AddSingleton<IPomodoroValidation, RestDurationValidation>();
    builder.Services.AddSingleton<IPomodoroValidation, WorkDurationValidation>();
}

static void RegisterSerivces(WebApplicationBuilder builder)
{
    builder.Services.AddControllers()
        .AddNewtonsoftJson(options =>
        {
            options.SerializerSettings.Converters.Add(new StringEnumConverter());
            options.SerializerSettings.ContractResolver = new DefaultContractResolver()
            {
                NamingStrategy = new CamelCaseNamingStrategy(),
            };
            options.SerializerSettings.Converters.Add(new JsonTypeMapper<IDuration, DurationDto>());
        });
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();

    builder.Services.AddSingleton<IUserIdentity, CurrentUser>();
    builder.Services.AddSingleton<IPomodoroProvider, PomodoroMockProvider>();
    builder.Services.AddSingleton<IPomodoroMapper, PomodoroMapper>();
    builder.Services.AddSingleton<PomodoroProvider>();

    RegisterValidationServices(builder);
}

RegisterSerivces(builder);


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
else
{

}

app.UseExceptionHandler("/error");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
//app.Use((context, next) =>
//{
//    //Access - Control - Allow - Origin
//    context.Response.Headers.AccessControlAllowOrigin = "http://localhost";
//    return next();
//});
app.Run();
