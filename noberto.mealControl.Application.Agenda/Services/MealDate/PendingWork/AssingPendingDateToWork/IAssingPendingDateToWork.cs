using noberto.mealControl.Core.Entities;

namespace noberto.mealControl.Application.BackgroundService.Services.MealDate.PendingWork.AssingPendingDateToWork;

public interface IAssingPendingDateToWork
{
    Task ToAssing(ScheduleEvent scheduleEvent, DateOnly date,
        ICollection<Work> works, ICollection<ScheduleLocalEvent> scheduleLocalEvents);
}
