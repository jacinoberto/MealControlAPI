using MediatR;
using noberto.mealControl.Core.Entities;

namespace noberto.mealControl.Application.CQRS.MealCQRS.Commands;

public class UpdateMealsCommand : IRequest<Meal>
{
    public Guid Id { get; set; }
    public bool Coffe { get; set; }
    public bool Lunch { get; set; }
    public bool Dinner { get; set; }

    public UpdateMealsCommand(Guid id, bool coffe, bool lunch, bool dinner,
        Guid administratorId)
    {
        Id = id;
        Coffe = coffe;
        Lunch = lunch;
        Dinner = dinner;
    }
}
