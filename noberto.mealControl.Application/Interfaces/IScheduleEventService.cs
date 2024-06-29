using noberto.mealControl.Application.DTOs.ScheduleEventDTO;

namespace noberto.mealControl.Application.Interfaces;

public interface IScheduleEventService
{
    Task CreateScheduleEventAsync(CreateScheduleEventDTO scheduleEventDto)
}
