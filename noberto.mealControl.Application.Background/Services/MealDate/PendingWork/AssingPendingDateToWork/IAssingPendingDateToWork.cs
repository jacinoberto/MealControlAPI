using noberto.mealControl.Core.Entities;

namespace noberto.mealControl.Application.Background.Services.MealDate.PendingWork.AssingPendingDateToWork;

public interface IAssingPendingDateToWork
{
    Task ToAssing(ScheduleEvent scheduleEvent, DateOnly date,
        ICollection<Work> works, ICollection<ScheduleLocalEvent> scheduleLocalEvents);
}
