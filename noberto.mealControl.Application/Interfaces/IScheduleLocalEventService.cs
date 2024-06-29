using noberto.mealControl.Application.DTOs.ScheduleEventDTO;
using noberto.mealControl.Application.DTOs.ScheduleLocalEventDTO;

namespace noberto.mealControl.Application.Interfaces;

public interface IScheduleLocalEventService
{
    Task CreateScheduleLocalEventAsync(CreateScheduleLocalEventDTO scheduleLocalEventDto);
}
