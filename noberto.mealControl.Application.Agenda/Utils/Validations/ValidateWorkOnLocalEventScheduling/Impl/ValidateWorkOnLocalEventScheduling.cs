using MediatR;
using noberto.mealControl.Application.CQRS.ScheduleLocalEventCQRS.Commands;
using noberto.mealControl.Core.Repositories;

namespace noberto.mealControl.Application.BackgroundService.Utils.Validations.ValidateWorkOnLocalEventScheduling.Impl;

public class ValidateWorkOnLocalEventScheduling : IValidateWorkOnLocalEventScheduling
{
    private readonly IWorkRepository _workRepository;
    private readonly IMediator _mediator;

    public ValidateWorkOnLocalEventScheduling(IWorkRepository workRepository, IMediator mediator)
    {
        _workRepository = workRepository;
        _mediator = mediator;
    }

    public async Task Validate(Guid scheduleEventId)
    {
        var works = await _workRepository.GetAllWorksAsync();

        foreach (var work in works)
        {
            var scheduleLocalEvent = new CreateScheduleLocalEventCommand(
                null, scheduleEventId, work.Id);

            await _mediator.Send(scheduleLocalEvent);
        }
    }
}
