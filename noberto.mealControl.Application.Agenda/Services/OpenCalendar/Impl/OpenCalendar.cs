using noberto.mealControl.Application.BackgroundService.Utils.Validations.ValidateAtypicalDay;
using noberto.mealControl.Application.DTOs.MealDTO;
using noberto.mealControl.Application.Interfaces;

namespace noberto.mealControl.Application.BackgroundService.Services.OpenCalendar.Impl;

public class OpenCalendar : IOpenCalendar
{
    private readonly IMealService _mealService;
    private readonly IScheduleLocalEventService _scheduleLocalEventService;
    private readonly ITeamService _teamService;
    private readonly IEnumerable<IValidateAtypicalDayStrategy> _validateDays;

    public OpenCalendar(IScheduleLocalEventService scheduleLocalEventService, ITeamService teamService, IEnumerable<IValidateAtypicalDayStrategy> validateDays, IMealService mealService)
    {
        _scheduleLocalEventService = scheduleLocalEventService;
        _teamService = teamService;
        _validateDays = validateDays;
        _mealService = mealService;
    }

    public async Task Open()
    {
        if (DateTime.Today.DayOfWeek == DayOfWeek.Sunday)
        {
            var scheduleLocalEvents = await _scheduleLocalEventService.GetScheduleLocalEventByDay();

            var teams = await _teamService.GetAllTeamsAsync();

            foreach (var scheduleLocalEvent in scheduleLocalEvents)
            {
                foreach (var team in teams)
                {
                    var meal = new CreateMealDTO();

                    foreach (var day in _validateDays)
                    {
                        meal = await day.Validate(team.Id, scheduleLocalEvent.ScheduleEventId, scheduleLocalEvent.Id);
                    }

                    //await _mealService.CreateMealAsync(meal);
                }
            }
        }
    }
}
