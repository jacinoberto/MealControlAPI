using MediatR;
using noberto.mealControl.Application.CQRS.ScheduleLocalEventCQRS.Queries;
using noberto.mealControl.Core.Entities;
using noberto.mealControl.Core.Repositories;

namespace noberto.mealControl.Application.CQRS.ScheduleLocalEventCQRS.Handles;

public class GetScheduleLocalEventByDayQueryHandler
    : IRequestHandler<GetScheduleLocalEventByDayQuery, IEnumerable<ScheduleLocalEvent>>
{
    private readonly IScheduleLocalEventRepository _repository;

    public GetScheduleLocalEventByDayQueryHandler(IScheduleLocalEventRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<ScheduleLocalEvent>> Handle(GetScheduleLocalEventByDayQuery request,
        CancellationToken cancellationToken)
    {
        return await _repository.GetScheduleLocalEventsByDay();
    }
}