using MediatR;
using noberto.mealControl.Core.Entities;

namespace noberto.mealControl.Application.CQRS.MealCQRS.Queries;

public class GetMealsByTeamManagementIdAndDateQuery : IRequest<IEnumerable<Meal>>
{
    public Guid TeamManagementId { get; set; }
    public DateOnly Date { get; set; }

    public GetMealsByTeamManagementIdAndDateQuery(Guid teamManagementId, DateOnly date)
    {
        TeamManagementId = teamManagementId;
        Date = date;
    }
}
