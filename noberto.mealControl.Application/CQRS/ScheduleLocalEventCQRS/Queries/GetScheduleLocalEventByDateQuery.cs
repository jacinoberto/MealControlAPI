using MediatR;
using noberto.mealControl.Core.Entities;

namespace noberto.mealControl.Application.CQRS.ScheduleLocalEventCQRS.Queries;

public class GetScheduleLocalEventByDateQuery : IRequest<IEnumerable<ScheduleLocalEvent>>
{
    public DateOnly Date { get; set; }

    public GetScheduleLocalEventByDateQuery(DateOnly date)
    {
        Date = date;
    }
}
