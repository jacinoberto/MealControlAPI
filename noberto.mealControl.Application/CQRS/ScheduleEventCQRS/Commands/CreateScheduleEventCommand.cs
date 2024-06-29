using MediatR;
using noberto.mealControl.Core.Entities;

namespace noberto.mealControl.Application.CQRS.ScheduleEventCQRS.Commands;

public class CreateScheduleEventCommand : IRequest<ScheduleEvent>
{
    public DateOnly MealDate { get; set; }
    public string Description { get; set; }
    public bool Atypical { get; set; }
    public Guid AdministratorId { get; set; }

    public CreateScheduleEventCommand(DateOnly mealDate, string description, bool atypical,
        Guid administratorId)
    {
        MealDate = mealDate;
        Description = description;
        Atypical = atypical;
        AdministratorId = administratorId;
    }
}
