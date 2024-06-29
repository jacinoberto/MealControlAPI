using MediatR;
using noberto.mealControl.Application.CQRS.ScheduleLocalEventCQRS.Commands;
using noberto.mealControl.Core.Entities;
using noberto.mealControl.Core.Repositories;

namespace noberto.mealControl.Application.CQRS.ScheduleLocalEventCQRS.Handles;

public class CreateScheduleLocalEventCommandHandle
    : IRequestHandler<CreateScheduleLocalEventCommand, ScheduleLocalEvent>
{
    private readonly IScheduleLocalEventRepository _repository;

    public CreateScheduleLocalEventCommandHandle(IScheduleLocalEventRepository repository)
    {
        _repository = repository;
    }

    public async Task<ScheduleLocalEvent> Handle(CreateScheduleLocalEventCommand request, CancellationToken cancellationToken)
    {
        var scheduleLocalEvent = new ScheduleLocalEvent();
        scheduleLocalEvent.AdministratorId = request.AdministratorId;
        scheduleLocalEvent.ScheduleEventId = request.ScheduleEventId;
        scheduleLocalEvent.WorkId = request.WorkId;

        return await _repository.CreateScheduleLocalEventAsync(scheduleLocalEvent);
    }
}
