using MediatR;
using noberto.mealControl.Core.Entities;

namespace noberto.mealControl.Application.CQRS.ScheduleLocalEventCQRS.Commands;

public class CreateScheduleLocalEventCommand : IRequest<ScheduleLocalEvent>
{
    public Guid AdministratorId { get; set; }
    public Guid ScheduleEventId { get; set; }
    public Guid WorkId { get; set; }

    public CreateScheduleLocalEventCommand(Guid administratorId, Guid scheduleEventId, Guid workId)
    {
        AdministratorId = administratorId;
        ScheduleEventId = scheduleEventId;
        WorkId = workId;
    }
}
