using Auth.Di;

using Pomodoro.Bll;
using Pomodoro.Di;
using Pomodoro.Service.MockUser;

using static Pomodoro.Service.AppServiceConfiguration;

var builder = WebApplication.CreateBuilder(args);

static void RegisterSerivces(WebApplicationBuilder builder)
{
    builder.Services.AddControllers()
        .AddNewtonsoftJson(
        options => ConfigureNewtonsoftJson(options)
        );
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();

    builder.Services.AddSingleton<IUserIdentity, CurrentUser>();
    builder.Services.AddSingleton<IPomodoroMapper, PomodoroMapper>();

    RegisterValidationServices(builder);
    RegisterProviders(builder);
}

RegisterSerivces(builder);

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
    });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
else
{

}


app.UseCors();
app.UseExceptionHandler("/error");

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseAuthentication();

app.MapControllers();
//app.Use((context, next) =>
//{
//    //Access - Control - Allow - Origin
//    context.Response.Headers.AccessControlAllowOrigin = "http://localhost";
//    return next();
//});
app.Run();
