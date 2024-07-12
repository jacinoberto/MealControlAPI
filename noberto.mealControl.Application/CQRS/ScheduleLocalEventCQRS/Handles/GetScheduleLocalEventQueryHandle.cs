using MediatR;
using noberto.mealControl.Application.CQRS.ScheduleLocalEventCQRS.Queries;
using noberto.mealControl.Core.Entities;
using noberto.mealControl.Core.Repositories;

namespace noberto.mealControl.Application.CQRS.ScheduleLocalEventCQRS.Handles;

public class GetScheduleLocalEventQueryHandle
    : IRequestHandler<GetScheduleLocalEventByDateQuery, IEnumerable<ScheduleLocalEvent>>
{
    private readonly IScheduleLocalEventRepository _repository;

    public GetScheduleLocalEventQueryHandle(IScheduleLocalEventRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<ScheduleLocalEvent>> Handle(GetScheduleLocalEventByDateQuery request,
        CancellationToken cancellationToken)
    {
        return await _repository.GetScheduleLocalEventByDate(request.Date);
    }
}
