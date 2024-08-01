using noberto.mealControl.Core.Entities;

namespace noberto.mealControl.Application.Background.Services.MealDate.PendingWork.AssingPendingWorksToDate;

public interface IAssingPendingWorksToDate
{
    Task ToAssing(ScheduleEvent scheduleEvent, DateOnly date);
}
