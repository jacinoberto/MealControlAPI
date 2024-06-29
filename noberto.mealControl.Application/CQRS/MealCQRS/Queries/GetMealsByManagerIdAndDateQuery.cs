using MediatR;
using noberto.mealControl.Core.Entities;

namespace noberto.mealControl.Application.CQRS.MealCQRS.Queries;

public class GetMealsByManagerIdAndDateQuery : IRequest<IEnumerable<Meal>>
{
    public Guid ManagerId { get; set; }
    public DateOnly Date { get; set; }

    public GetMealsByManagerIdAndDateQuery(Guid managerId, DateOnly date)
    {
        ManagerId = managerId;
        Date = date;
    }
}
