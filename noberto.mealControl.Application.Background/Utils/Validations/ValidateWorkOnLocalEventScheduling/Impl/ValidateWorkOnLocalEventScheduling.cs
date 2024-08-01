using MediatR;
using noberto.mealControl.Application.CQRS.ScheduleLocalEventCQRS.Commands;
using noberto.mealControl.Application.DTOs.ScheduleEventDTO;
using noberto.mealControl.Application.DTOs.ScheduleLocalEventDTO;
using noberto.mealControl.Application.Interfaces;
using noberto.mealControl.Core.Repositories;

namespace noberto.mealControl.Application.Background.Utils.Validations.ValidateWorkOnLocalEventScheduling.Impl;

public class ValidateWorkOnLocalEventScheduling : IValidateWorkOnLocalEventScheduling
{
    private readonly IWorkService _service;
    private readonly IScheduleLocalEventService _scheduleLocalEventService;
    private readonly IMediator _mediator;

    public ValidateWorkOnLocalEventScheduling(IMediator mediator, IWorkService service, IScheduleLocalEventService scheduleLocalEventService)
    {
        _mediator = mediator;
        _service = service;
        _scheduleLocalEventService = scheduleLocalEventService;
    }

    public async Task Validate(Guid scheduleEventId)
    {
        var works = await _service.GetAllWorkAsync();
        var result = await _scheduleLocalEventService.GetScheduleLocalEventByScheduleEventIdAsync(scheduleEventId);

        if (result is null)
        {
            foreach (var work in works)
            {                
                var scheduleLocalEvent = new CreateScheduleLocalEventDTO(
                    null, scheduleEventId, work.Id);
                                
                await _scheduleLocalEventService.CreateScheduleLocalEventAsync(scheduleLocalEvent);
            }
        }
    }
}
