using noberto.mealControl.Application.DTOs.WorkDTO;
using noberto.mealControl.Core.Entities;

namespace noberto.mealControl.Application.BackgroundService.Services.MealDate.PendingWork.AssingDateToWork;

public interface IAssingDateToWork
{
    Task ToAssing(ISet<WorkIdDTO> works, ScheduleEvent scheduleEvent);
}
