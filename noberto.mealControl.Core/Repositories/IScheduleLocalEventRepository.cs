using noberto.mealControl.Core.Entities;

namespace noberto.mealControl.Core.Repositories;

public interface IScheduleLocalEventRepository
{
    Task<ScheduleLocalEvent> CreateScheduleLocalEventAsync(ScheduleLocalEvent scheduleLocalEvent);
    Task<ICollection<ScheduleLocalEvent>> GetScheduleLocalEventByDate(DateOnly date);
    Task<ScheduleLocalEvent> GetScheduleLocalEventByWorkId(Guid workId);
    Task<ScheduleLocalEvent?> GetScheduleLocalEventByScheduleEventId(Guid scheduleEventId);
    Task<ICollection<ScheduleLocalEvent>> GetScheduleLocalEventByIdAndDateAndDayAtypical(Guid workId, DateOnly mealDate, bool atypicalDay);
    Task<IEnumerable<ScheduleLocalEvent>> GetScheduleLocalEventsByDay();
}
