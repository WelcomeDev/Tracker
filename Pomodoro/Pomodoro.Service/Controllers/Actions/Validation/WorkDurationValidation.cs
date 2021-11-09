using Pomodoro.Service.Controllers.Dto;
using Pomodoro.Service.Controllers.Exceptions;

namespace Pomodoro.Service.Controllers.Actions
{
    public class WorkDurationValidation : IPomodoroValidation
    {
        private readonly IConfiguration _configuration;

        public WorkDurationValidation(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void Validate(PomodoroCreationDto dto)
        {
            int maxHour = int.Parse(_configuration["Validation:Duration:MaxWorkHour"]);
            int minHour = int.Parse(_configuration["Validation:Duration:MinWorkHour"]);
            int minMinute = int.Parse(_configuration["Validation:Duration:MinMinute"]);
            int maxMinute = 59;

            var duration = dto.WorkDuration;
            if (duration.Hours > maxHour || duration.Hours < minHour)
                throw new PomodoroValidationException($"Invalid work duration. Hours must be between {minHour} and {maxHour}");

            if (duration.Minutes > maxMinute)
                throw new PomodoroValidationException($"Invalid work duration. Minutes must be less than {maxMinute}");

            if (duration.Hours == 0 && duration.Minutes < minMinute)
                throw new PomodoroValidationException($"Invalid work duration. Minutes must be bigger than {minMinute}");
        }
    }
}
