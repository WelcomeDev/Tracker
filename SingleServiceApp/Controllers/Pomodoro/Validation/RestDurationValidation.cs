using Pomodoro.Service.Controllers.Exceptions;

using SingleServiceApp.Controllers.Pomodoro.Dto;

namespace SingleServiceApp.Controllers.Pomodoro.Validation
{
    public class RestDurationValidation : IPomodoroValidation
    {
        private readonly IConfiguration _configuration;

        public RestDurationValidation(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void Validate(PomodoroCreationDto dto)
        {
            int maxHour = int.Parse(_configuration["Validation:Duration:MaxRestHour"]);
            int minHour = int.Parse(_configuration["Validation:Duration:MinHour"]);
            int minMinute = int.Parse(_configuration["Validation:Duration:MinMinute"]);
            int maxMinute = 59;

            var duration = dto.RestDuration;
            if (duration.Hours > maxHour || duration.Hours < minHour)
                throw new PomodoroValidationException($"Invalid rest duration. Hours must be between {minHour} and {maxHour}");

            if (duration.Minutes > maxMinute)
                throw new PomodoroValidationException($"Invalid rest duration. Minutes must be less than {maxMinute}");

            if (duration.Hours == 0 && duration.Minutes < minMinute)
                throw new PomodoroValidationException($"Invalid rest duration. Minutes must be bigger than {minMinute}");
        }
    }
}
