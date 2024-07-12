using MediatR;
using noberto.mealControl.Core.Entities;

namespace noberto.mealControl.Application.CQRS.ScheduleLocalEventCQRS.Queries;

public class GetSchduleLocalEventByWorkIdAndMealDateAndAtypicalQuery
    : IRequest<IEnumerable<ScheduleLocalEvent>>
{
    public Guid WorkId { get; set; }
    public DateOnly MealDate { get; set; }
    public bool Atypical { get; set; }

    public GetSchduleLocalEventByWorkIdAndMealDateAndAtypicalQuery(Guid workId, DateOnly mealDate,
        bool atypical)
    {
        WorkId = workId;
        MealDate = mealDate;
        Atypical = atypical;
    }
}
