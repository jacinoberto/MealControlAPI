using AutoMapper;
using noberto.mealControl.Application.Background.Utils.Validations.ValidateWeekend;
using noberto.mealControl.Application.Background.Utils.Validations.ValidateWorkOnLocalEventScheduling;
using noberto.mealControl.Application.Interfaces;
using noberto.mealControl.Core.Entities;

namespace noberto.mealControl.Application.Background.Services.MealDate.PendingWork.AssingPendingWorksToDate.Impl;

public class AssingPendingWorksToDate : IAssingPendingWorksToDate
{
    private readonly IValidateWeekendStrategy _validateWeekend;
    private readonly IScheduleEventService _scheduleEventService;
    private readonly IValidateWorkOnLocalEventScheduling _validateWork;
    private readonly IMapper _mapper;

    public AssingPendingWorksToDate(IValidateWeekendStrategy validateWeekend, IScheduleEventService scheduleEventService, IMapper mapper, IValidateWorkOnLocalEventScheduling validateWork)
    {
        _validateWeekend = validateWeekend;
        _scheduleEventService = scheduleEventService;
        _mapper = mapper;
        _validateWork = validateWork;
    }

    public async Task ToAssing(ScheduleEvent scheduleEvent, DateOnly date)
    {
        if (scheduleEvent is null)
        {
            var createScheduleEvent = _validateWeekend.Validate(date);
            var result = await _scheduleEventService.CreateScheduleEventAsync(createScheduleEvent);
            await _validateWork.Validate(result.Id);
        }
    }
}
