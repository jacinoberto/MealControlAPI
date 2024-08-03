using MediatR;
using noberto.mealControl.Core.Entities;

namespace noberto.mealControl.Application.CQRS.MealCQRS.Commands;

public class UpdateMealDinnerCommand : IRequest<Meal>
{
    public Guid Id { get; set; }
    public bool Dinner { get; set; }

    public UpdateMealDinnerCommand(Guid id, bool dinner)
    {
        Dinner = dinner;
        Id = id;
    }
}
