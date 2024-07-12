using MediatR;
using noberto.mealControl.Core.Entities;

namespace noberto.mealControl.Application.CQRS.ScheduleEventCQRS.Queries;

public class GetScheduleEventByDateQuery : IRequest<ScheduleEvent>
{
    public DateOnly Date { get; set; }

    public GetScheduleEventByDateQuery(DateOnly date)
    {
        Date = date;
    }
}
