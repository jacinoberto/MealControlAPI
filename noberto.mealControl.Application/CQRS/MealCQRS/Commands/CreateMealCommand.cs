using MediatR;
using noberto.mealControl.Core.Entities;

namespace noberto.mealControl.Application.CQRS.MealCQRS.Commands;

public class CreateMealCommand : IRequest<Meal>
{
    public bool Coffe { get; set; }
    public bool Lunch { get; set; }
    public bool Dinner { get; set; }
    public Guid AdministratorId { get; set; }
    public Guid TeamId { get; set; }
    public Guid ScheduleLocalEventId { get; set; }

    public CreateMealCommand()
    {
        
    }

    public CreateMealCommand(bool coffe, bool lunch, bool dinner, Guid administratorId,
        Guid teamId, Guid scheduleLocalEventId)
    {
        Coffe = coffe;
        Lunch = lunch;
        Dinner = dinner;
        AdministratorId = administratorId;
        TeamId = teamId;
        ScheduleLocalEventId = scheduleLocalEventId;
    }
}
