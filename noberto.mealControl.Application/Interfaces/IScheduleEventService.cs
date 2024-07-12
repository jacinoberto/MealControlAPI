using noberto.mealControl.Application.DTOs.ScheduleEventDTO;

namespace noberto.mealControl.Application.Interfaces;

public interface IScheduleEventService
{
    Task<ReturnScheduleEventDTO> CreateScheduleEventAsync(CreateScheduleEventDTO scheduleEventDto);
    Task<ReturnScheduleEventDTO> GetScheduleEventByDateAsync(DateOnly date);
}
