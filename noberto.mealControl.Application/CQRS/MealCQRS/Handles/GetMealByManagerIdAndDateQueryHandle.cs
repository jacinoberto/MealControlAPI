using AutoMapper;
using MediatR;
using noberto.mealControl.Application.CQRS.MealCQRS.Queries;
using noberto.mealControl.Core.Entities;
using noberto.mealControl.Core.Repositories;

namespace noberto.mealControl.Application.CQRS.MealCQRS.Handles;

public class GetMealByManagerIdAndDateQueryHandle
    : IRequestHandler<GetMealsByManagerIdAndDateQuery, IEnumerable<Meal>>
{
    private readonly IMealRepository _repository;

    public GetMealByManagerIdAndDateQueryHandle(IMealRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<Meal>> Handle(GetMealsByManagerIdAndDateQuery request, CancellationToken cancellationToken)
    {
        return await _repository.GetMealsByIdManagerAndDateAsync(request.ManagerId, request.Date);
    }
}
