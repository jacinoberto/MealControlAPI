using MediatR;
using noberto.mealControl.Application.CQRS.MealCQRS.Queries;
using noberto.mealControl.Core.Entities;
using noberto.mealControl.Core.Repositories;

namespace noberto.mealControl.Application.CQRS.MealCQRS.Handles;

public class GetMealByStartDateAndClosingDateAndManagerIdQueryHandle
    : IRequestHandler<GetMealByStartDateAndClosingDateAndManagerIdQuery, IEnumerable<Meal>>
{
    private readonly IMealRepository _repository;

    public GetMealByStartDateAndClosingDateAndManagerIdQueryHandle(IMealRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<Meal>> Handle(GetMealByStartDateAndClosingDateAndManagerIdQuery request, CancellationToken cancellationToken)
    {
        return await _repository.GetMealsByStartDateAndClosingDateAndManagerIdAsync(
            request.StartDate, request.ClosingDate, request.ManagerId);
    }
}
