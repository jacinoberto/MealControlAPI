using MediatR;
using noberto.mealControl.Core.Entities;

namespace noberto.mealControl.Application.CQRS.MealCQRS.Commands;

public class UpdateMealCoffeeCommand : IRequest<Meal>
{
    public Guid Id { get; set; }
    public bool Coffee { get; set; }

    public UpdateMealCoffeeCommand(Guid id, bool coffee)
    {
        Coffee = coffee;
        Id = id;
    }
}
