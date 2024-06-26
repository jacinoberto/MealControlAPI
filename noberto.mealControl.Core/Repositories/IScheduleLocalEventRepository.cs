using noberto.mealControl.Core.Entities;

namespace noberto.mealControl.Core.Repositories;

public interface IScheduleLocalEventRepository
{
    Task<ScheduleLocalEvent> CreateScheduleLocalEventAsync(ScheduleLocalEvent scheduleLocalEvent);
}
