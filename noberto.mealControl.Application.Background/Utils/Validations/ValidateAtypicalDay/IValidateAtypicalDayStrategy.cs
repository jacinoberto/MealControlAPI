using noberto.mealControl.Application.DTOs.ScheduleEventDTO;
using noberto.mealControl.Application.DTOs.ScheduleLocalEventDTO;
using noberto.mealControl.Application.DTOs.TeamDTO;

namespace noberto.mealControl.Application.Background.Utils.Validations.ValidateAtypicalDay;

public interface IValidateAtypicalDayStrategy
{
    Task Validate(ReturnTeamDTO team, ReturnScheduleEventDTO scheduleEvent, ReturnScheduleLocalEventDTO scheduleLocalEvent);
}
