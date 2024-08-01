using MediatR;
using noberto.mealControl.Core.Entities;

namespace noberto.mealControl.Application.CQRS.ScheduleLocalEventCQRS.Queries;

public class GetScheduleLocalEventByScheduleEventIdQuery : IRequest<ScheduleLocalEvent>
{
    public Guid ScheduleEventId { get; set; }

    public GetScheduleLocalEventByScheduleEventIdQuery(Guid scheduleEventId)
    {
        ScheduleEventId = scheduleEventId;
    }
}
