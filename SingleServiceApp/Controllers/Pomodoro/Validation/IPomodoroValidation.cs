
using SingleServiceApp.Controllers.Pomodoro.Dto;

namespace SingleServiceApp.Controllers.Pomodoro.Validation
{
    public interface IPomodoroValidation
    {
        void Validate(PomodoroCreationDto dto);
    }
}
