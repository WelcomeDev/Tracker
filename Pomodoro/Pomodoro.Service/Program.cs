using Auth.Di;

using Pomodoro.Bll;
using Pomodoro.Bll.Provider.Mock;
using Pomodoro.Di;
using Pomodoro.Di.Duration;
using Pomodoro.Di.Provider;
using Pomodoro.Service.Controllers.Dto;
using Pomodoro.Service.MockUser;
using Pomodoro.Service.Providers;
using System.Text.Json;
using WelcomeDev.Utils;

var builder = WebApplication.CreateBuilder(args);

static void RegisterSerivces(WebApplicationBuilder builder)
{
    builder.Services.AddControllers();
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();

    builder.Services.AddSingleton<IUserIdentity, CurrentUser>();
    builder.Services.AddSingleton<IPomodoroProvider, PomodoroMockProvider>();
    builder.Services.AddSingleton<IPomodoroMapper, PomodoroMapper>();
    builder.Services.AddSingleton<PomodoroProvider>();
    builder.Services.AddControllersWithViews().AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
        options.JsonSerializerOptions.Converters.Add(new TypeMappingConverter<IDuration, DurationDto>());
    });
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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
