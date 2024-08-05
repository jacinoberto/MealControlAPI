using noberto.mealControl.Application.Background.Utils.Validations.ValidateAtypicalDay;
using noberto.mealControl.Application.Interfaces;

namespace noberto.mealControl.Application.Background.Services.OpenCalendar.Impl;

public class OpenCalendarImpl : IOpenCalendar
{
    private readonly ITeamService _teamService;
    private readonly IScheduleLocalEventService _scheduleLocalEventService;
    private readonly IEnumerable<IValidateAtypicalDayStrategy> _validateDays;

    public OpenCalendarImpl(IScheduleLocalEventService scheduleLocalEventService, ITeamService teamService, IEnumerable<IValidateAtypicalDayStrategy> validateDays)
    {
        _scheduleLocalEventService = scheduleLocalEventService;
        _teamService = teamService;
        _validateDays = validateDays;
    }

    public async Task Open()
    {
        if (DateTime.Today.DayOfWeek == DayOfWeek.Sunday)
        {
            var scheduleLocalEvents = await _scheduleLocalEventService.GetScheduleLocalEventByDay();

            var teams = await _teamService.GetAllTeamsAsync();

            foreach (var scheduleLocalEvent in scheduleLocalEvents)
            {
                int valor = scheduleLocalEvents.Count();

                foreach (var team in teams)
                {
                    var teamAdministrator = await _teamService.GetTeamByIdAsync(team.Id);

                    foreach (var day in _validateDays)
                    {
                        await day.Validate(team, scheduleLocalEvent.ScheduleEvent, scheduleLocalEvent);
                    }
                }
            }
        }
    }
}
