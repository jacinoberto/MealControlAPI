using MediatR;
using noberto.mealControl.Application.CQRS.ScheduleLocalEventCQRS.Queries;
using noberto.mealControl.Core.Entities;
using noberto.mealControl.Core.Repositories;

namespace noberto.mealControl.Application.CQRS.ScheduleLocalEventCQRS.Handles;

public class GetScheduleLocalEventByWorkIdAndMealDateAndAtypicalQueryHandle
    : IRequestHandler<GetSchduleLocalEventByWorkIdAndMealDateAndAtypicalQuery,
        IEnumerable<ScheduleLocalEvent>>
{
    private readonly IScheduleLocalEventRepository _repository;

    public GetScheduleLocalEventByWorkIdAndMealDateAndAtypicalQueryHandle(
        IScheduleLocalEventRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<ScheduleLocalEvent>> Handle(GetSchduleLocalEventByWorkIdAndMealDateAndAtypicalQuery request,
        CancellationToken cancellationToken)
    {
        return await _repository.GetScheduleLocalEventByIdAndDateAndDayAtypical(request.WorkId, request.MealDate, request.Atypical);    
    }
}
