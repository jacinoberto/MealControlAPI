using MediatR;
using noberto.mealControl.Application.CQRS.MealCQRS.Queries;
using noberto.mealControl.Core.Entities;
using noberto.mealControl.Core.Repositories;

namespace noberto.mealControl.Application.CQRS.MealCQRS.Handles;

public class GetMealByDateQueryHandle
    : IRequestHandler<GetMealByDateQuery, IEnumerable<Meal>>
{
    private readonly IMealRepository _repository;

    public GetMealByDateQueryHandle(IMealRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<Meal>> Handle(GetMealByDateQuery request, CancellationToken cancellationToken)
    {
        return await _repository.GetMealByDate(request.Date);
    }
}
