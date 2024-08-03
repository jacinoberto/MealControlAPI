using MediatR;
using noberto.mealControl.Core.Entities;

namespace noberto.mealControl.Application.CQRS.MealCQRS.Queries;

public class GetMealByDateQuery : IRequest<IEnumerable<Meal>>
{
    public DateOnly Date { get; set; }

    public GetMealByDateQuery(DateOnly date)
    {
        Date = date;
    }
}
