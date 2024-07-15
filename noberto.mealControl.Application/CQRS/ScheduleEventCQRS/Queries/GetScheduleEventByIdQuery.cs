using MediatR;
using noberto.mealControl.Core.Entities;

namespace noberto.mealControl.Application.CQRS.ScheduleEventCQRS.Queries;

public class GetScheduleEventByIdQuery : IRequest<ScheduleEvent>
{
    public Guid Id { get; set; }

    public GetScheduleEventByIdQuery(Guid id)
    {
        Id = id;
    }
}
