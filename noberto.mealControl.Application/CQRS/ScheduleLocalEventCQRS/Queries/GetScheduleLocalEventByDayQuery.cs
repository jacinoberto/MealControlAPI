using MediatR;
using noberto.mealControl.Core.Entities;

namespace noberto.mealControl.Application.CQRS.ScheduleLocalEventCQRS.Queries;

public class GetScheduleLocalEventByDayQuery : IRequest<IEnumerable<ScheduleLocalEvent>>
{
}
