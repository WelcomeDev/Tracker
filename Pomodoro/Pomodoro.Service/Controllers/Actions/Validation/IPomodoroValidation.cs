using Pomodoro.Service.Controllers.Dto;

namespace Pomodoro.Service.Controllers.Actions.Validation
{
    public interface IPomodoroValidation
    {
        void Validate(PomodoroCreationDto dto);
    }
}
