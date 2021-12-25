using Pomodoro.Service.Controllers.Exceptions;

using SingleServiceApp.Controllers.Pomodoro.Dto;

namespace SingleServiceApp.Controllers.Pomodoro.Validation
{
    public class TitleValidation : IPomodoroValidation
    {
        private const string EmptiTitleValidationMessage = "Title can't be empty";

        private readonly IConfiguration _configuration;

        public TitleValidation(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void Validate(PomodoroCreationDto dto)
        {
            string title = dto.Title;
            if (string.IsNullOrWhiteSpace(title))
                throw new PomodoroValidationException(EmptiTitleValidationMessage);

            int maxLength = int.Parse(_configuration["Validation:Title:MaxLength"]);
            if (title.Length > maxLength)
                throw new PomodoroValidationException($"Title length must be shorter than {maxLength}");
        }
    }
}
