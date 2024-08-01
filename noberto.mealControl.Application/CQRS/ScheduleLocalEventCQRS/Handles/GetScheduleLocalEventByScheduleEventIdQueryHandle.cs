using MediatR;
using noberto.mealControl.Application.CQRS.ScheduleLocalEventCQRS.Queries;
using noberto.mealControl.Core.Entities;
using noberto.mealControl.Core.Repositories;

namespace noberto.mealControl.Application.CQRS.ScheduleLocalEventCQRS.Handles;

public class GetScheduleLocalEventByScheduleEventIdQueryHandle
    : IRequestHandler<GetScheduleLocalEventByScheduleEventIdQuery, ScheduleLocalEvent>
{
    private readonly IScheduleLocalEventRepository _repository;

    public GetScheduleLocalEventByScheduleEventIdQueryHandle(IScheduleLocalEventRepository repository)
    {
        _repository = repository;
    }

    public async Task<ScheduleLocalEvent?> Handle(GetScheduleLocalEventByScheduleEventIdQuery request, CancellationToken cancellationToken)
    {
        return await _repository.GetScheduleLocalEventByScheduleEventId(request.ScheduleEventId);
    }
}
