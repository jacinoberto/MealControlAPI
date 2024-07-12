using noberto.mealControl.Core.Entities;

namespace noberto.mealControl.Application.BackgroundService.Services.MealDate.PendingWork.AssingPendingWorksToDate;

public interface IAssingPendingWorksToDate
{
    Task ToAssing(ScheduleEvent scheduleEvent, DateOnly date);
}
