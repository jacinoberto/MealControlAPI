using noberto.mealControl.Core.Entities;

namespace noberto.mealControl.Core.Repositories;

public interface IScheduleEventRepository
{
    Task<ScheduleEvent> CreateScheduleEventAsync(ScheduleEvent schedule);
    Task<ScheduleEvent> GetScheduleEventbyDateAsync(DateOnly date);
}
