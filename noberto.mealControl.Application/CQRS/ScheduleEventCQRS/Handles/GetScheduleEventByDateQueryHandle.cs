using MediatR;
using noberto.mealControl.Application.CQRS.ScheduleEventCQRS.Queries;
using noberto.mealControl.Core.Entities;
using noberto.mealControl.Core.Repositories;

namespace noberto.mealControl.Application.CQRS.ScheduleEventCQRS.Handles;

public class GetScheduleEventByDateQueryHandle
    : IRequestHandler<GetScheduleEventByDateQuery, ScheduleEvent>
{
    private readonly IScheduleEventRepository _repository;

    public GetScheduleEventByDateQueryHandle(IScheduleEventRepository repository)
    {
        _repository = repository;
    }

    public async Task<ScheduleEvent?> Handle(GetScheduleEventByDateQuery request, CancellationToken cancellationToken)
    {
        var schedule = await _repository.GetScheduleEventbyDateAsync(request.Date);

        return schedule is not null ? schedule
            : null;
    }
}
