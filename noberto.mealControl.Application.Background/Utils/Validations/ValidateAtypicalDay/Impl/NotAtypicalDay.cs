using noberto.mealControl.Application.DTOs.MealDTO;
using noberto.mealControl.Application.DTOs.ScheduleEventDTO;
using noberto.mealControl.Application.DTOs.ScheduleLocalEventDTO;
using noberto.mealControl.Application.DTOs.TeamDTO;
using noberto.mealControl.Application.Interfaces;

namespace noberto.mealControl.Application.Background.Utils.Validations.ValidateAtypicalDay.Impl;

public class NotAtypicalDay : IValidateAtypicalDayStrategy
{
    private readonly IMealService _mealService;

    public NotAtypicalDay(IMealService mealService)
    {
        _mealService = mealService;
    }

    public async Task Validate(ReturnTeamDTO team, ReturnScheduleEventDTO scheduleEvent, ReturnScheduleLocalEventDTO scheduleLocalEvent)
    {
        if (!scheduleEvent.Atypical
            && scheduleLocalEvent.WorkId == team.TeamManagement.WorkId)
        {
            CreateMealDTO meal = new(true, true, true, team.AdministratorId, team.Id,
                scheduleLocalEvent.Id);

            await _mealService.CreateMealAsync(meal);
        }
    }
}
