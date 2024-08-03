using MediatR;
using noberto.mealControl.Core.Entities;

namespace noberto.mealControl.Application.CQRS.MealCQRS.Queries;

public class GetMealByStartDateAndClosingDateAndManagerIdQuery : IRequest<IEnumerable<Meal>>
{
    public DateOnly StartDate { get; set; }
    public DateOnly ClosingDate { get; set; }
    public Guid ManagerId { get; set; }

    public GetMealByStartDateAndClosingDateAndManagerIdQuery(DateOnly startDate,
        DateOnly closingDate, Guid managerId)
    {
        StartDate = startDate;
        ClosingDate = closingDate;
        ManagerId = managerId;
    }
}
