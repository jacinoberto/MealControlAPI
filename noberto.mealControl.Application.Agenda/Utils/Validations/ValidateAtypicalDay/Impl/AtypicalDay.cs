using noberto.mealControl.Application.DTOs.MealDTO;
using noberto.mealControl.Application.DTOs.ScheduleEventDTO;
using noberto.mealControl.Application.DTOs.ScheduleLocalEventDTO;
using noberto.mealControl.Application.DTOs.TeamDTO;
using noberto.mealControl.Application.Interfaces;
using noberto.mealControl.Core.Entities;
using noberto.mealControl.Core.Repositories;
using System.Runtime.InteropServices;

namespace noberto.mealControl.Application.BackgroundService.Utils.Validations.ValidateAtypicalDay.Impl;

public class AtypicalDay : IValidateAtypicalDayStrategy
{
    private readonly IMealService _mealService;
    private readonly ITeamManagementRepository _teamManagementService;


    public AtypicalDay(IMealService mealService, ITeamManagementRepository teamManagementService)
    {
        _mealService = mealService;
        _teamManagementService = teamManagementService;
    }

    public async Task Validate(ReturnTeamDTO team, ReturnScheduleEventDTO scheduleEvent, ReturnScheduleLocalEventDTO scheduleLocalEvent)
    {
        if (scheduleEvent.Atypical
            && scheduleLocalEvent.WorkId == team.TeamManagement.WorkId)
        {
            CreateMealDTO meal = new(false, false, false, team.AdministratorId, team.Id,
                scheduleLocalEvent.Id);

            await _mealService.CreateMealAsync(meal);
        }
    }
}
