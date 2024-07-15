using AutoMapper;
using noberto.mealControl.Application.DTOs.MealDTO;
using noberto.mealControl.Application.DTOs.ScheduleLocalEventDTO;
using noberto.mealControl.Application.Interfaces;
using noberto.mealControl.Core.Entities;
using noberto.mealControl.Core.Repositories;

namespace noberto.mealControl.Application.BackgroundService.Utils.Validations.ValidateAtypicalDay.Impl;

public class NotAtypicalDay : IValidateAtypicalDayStrategy
{
    private readonly IScheduleEventService _scheduleEventService;
    private readonly IMealService _mealService;
    private readonly IMealRepository _mealRepository;
    private readonly IMapper _mapper;

    public NotAtypicalDay(IScheduleEventService scheduleEventService, IMealService mealService, IMealRepository mealRepository, IMapper mapper)
    {
        _scheduleEventService = scheduleEventService;
        _mealService = mealService;
        _mealRepository = mealRepository;
        _mapper = mapper;
    }

    public async Task<CreateMealDTO> Validate(Guid teamId, Guid scheduleEventId, Guid scheduleLocalEvent)
    {
        var meal = new CreateMealDTO();
        var scheduleEvent = await _scheduleEventService.GetScheduleEventByIdAsync(scheduleEventId);

        if (!scheduleEvent.Atypical)
        {
            meal = new(true, true, true, null, teamId,
                scheduleLocalEvent);

            //await _mealService.CreateMealAsync(meal);
            await _mealRepository.CreateMealAsync(_mapper.Map<Meal>(meal));
        }

        return meal;
    }
}
