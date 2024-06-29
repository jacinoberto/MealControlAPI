using MediatR;
using noberto.mealControl.Application.CQRS.ScheduleEventCQRS.Commands;
using noberto.mealControl.Core.Entities;
using noberto.mealControl.Core.Repositories;

namespace noberto.mealControl.Application.CQRS.ScheduleEventCQRS.Handles;

public class CreateScheduleEventCommandHandle
    : IRequestHandler<CreateScheduleEventCommand, ScheduleEvent>
{
    private readonly IScheduleEventRepository _repository;

    public CreateScheduleEventCommandHandle(IScheduleEventRepository repository)
    {
        _repository = repository;
    }

    public async Task<ScheduleEvent> Handle(CreateScheduleEventCommand request, CancellationToken cancellationToken)
    {
        var scheduleEvent = new ScheduleEvent(request.MealDate, request.Description, request.Atypical);

        return await _repository.CreateScheduleEventAsync(scheduleEvent);
    }
}
