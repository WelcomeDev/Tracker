using Pomodoro.Service.Controllers.Dto;

namespace Pomodoro.Service.Controllers.Actions
{
    public interface IPomodoroValidation
    {
        void Validate(PomodoroCreationDto dto);
    }
}
