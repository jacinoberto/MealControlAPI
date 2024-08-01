using noberto.mealControl.Application.DTOs.ScheduleEventDTO;
using noberto.mealControl.Application.DTOs.ScheduleLocalEventDTO;

namespace noberto.mealControl.Application.Interfaces;

public interface IScheduleLocalEventService
{
    Task<ReturnScheduleLocalEventDTO> CreateScheduleLocalEventAsync(CreateScheduleLocalEventDTO scheduleLocalEventDto);
    Task<IEnumerable<ReturnScheduleLocalEventDTO>> GetScheduleLocalEventByDay();
    Task<ReturnScheduleLocalEventDTO> GetScheduleLocalEventByScheduleEventIdAsync(Guid scheduleEventId);
    Task<ICollection<ReturnScheduleLocalEventDTO>> GetScheduleLocalEventByDateAsync(DateOnly date);
    Task<ICollection<ReturnScheduleLocalEventDTO>> GetScheduleLocalEventByWorkIdAndMealDateAndAtypicalAsync(Guid workId, DateOnly mealDate, bool Atypical);
}
