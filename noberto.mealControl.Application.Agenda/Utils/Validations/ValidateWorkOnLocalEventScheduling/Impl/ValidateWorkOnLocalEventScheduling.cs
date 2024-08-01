using MediatR;
using noberto.mealControl.Application.CQRS.ScheduleLocalEventCQRS.Commands;
using noberto.mealControl.Application.Interfaces;
using noberto.mealControl.Core.Repositories;

namespace noberto.mealControl.Application.BackgroundService.Utils.Validations.ValidateWorkOnLocalEventScheduling.Impl;

public class ValidateWorkOnLocalEventScheduling : IValidateWorkOnLocalEventScheduling
{
    private readonly IWorkService _service;
    private readonly IMediator _mediator;

    public ValidateWorkOnLocalEventScheduling(IMediator mediator, IWorkService service)
    {
        _mediator = mediator;
        _service = service;
    }

    public async Task Validate(Guid scheduleEventId)
    {
        var works = await _service.GetAllWorkAsync();

        foreach (var work in works)
        {
            var scheduleLocalEvent = new CreateScheduleLocalEventCommand(
                null, scheduleEventId, work.Id);

            await _mediator.Send(scheduleLocalEvent);
        }
    }
}
