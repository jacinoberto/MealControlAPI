using noberto.mealControl.Application.DTOs.MealDTO;
using noberto.mealControl.Application.DTOs.ScheduleLocalEventDTO;
using noberto.mealControl.Application.Interfaces;

namespace noberto.mealControl.Application.BackgroundService.Utils.Validations.ValidateAtypicalDay.Impl;

public class AtypicalDay : IValidateAtypicalDayStrategy
{
    private readonly IScheduleEventService _scheduleEventService;

    public AtypicalDay(IScheduleEventService scheduleEventService)
    {
        _scheduleEventService = scheduleEventService;
    }

    public async Task<CreateMealDTO> Validate(Guid teamId, Guid scheduleEventId, Guid scheduleLocalEvent)
    {
        var meal = new CreateMealDTO();
        var scheduleEvent = await _scheduleEventService.GetScheduleEventByIdAsync(scheduleEventId);

        if (scheduleEvent.Atypical)
        {
            meal = new(false, false, false, scheduleEvent.AdministratorId, teamId,
                scheduleLocalEvent);
        }

        return meal;
    }
}
