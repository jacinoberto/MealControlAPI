using MediatR;
using noberto.mealControl.Core.Entities;

namespace noberto.mealControl.Application.CQRS.MealCQRS.Commands;

public class UpdateMealLunchCommand : IRequest<Meal>
{
    public Guid Id { get; set; }
    public bool Lunch { get; set; }

    public UpdateMealLunchCommand(Guid id, bool lunch)
    {
        Lunch = lunch;
        Id = id;
    }
}
