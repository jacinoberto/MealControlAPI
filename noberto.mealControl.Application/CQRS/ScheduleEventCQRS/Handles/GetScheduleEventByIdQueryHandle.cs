using MediatR;
using noberto.mealControl.Application.CQRS.ScheduleEventCQRS.Queries;
using noberto.mealControl.Core.Entities;
using noberto.mealControl.Core.Repositories;

namespace noberto.mealControl.Application.CQRS.ScheduleEventCQRS.Handles;

public class GetScheduleEventByIdQueryHandle
    : IRequestHandler<GetScheduleEventByIdQuery, ScheduleEvent>
{
    private readonly IScheduleEventRepository _repository;

    public GetScheduleEventByIdQueryHandle(IScheduleEventRepository repository)
    {
        _repository = repository;
    }

    public async Task<ScheduleEvent> Handle(GetScheduleEventByIdQuery request,
        CancellationToken cancellationToken)
    {
        return await _repository.GetScheduleEventbyIdAsync(request.Id);
    }
}
