using AutoMapper;
using MediatR;
using noberto.mealControl.Application.CQRS.MealCQRS.Queries;
using noberto.mealControl.Core.Entities;
using noberto.mealControl.Core.Repositories;

namespace noberto.mealControl.Application.CQRS.MealCQRS.Handles;

public class GetMealByTeamManagementIdIdAndDateQueryHandle
    : IRequestHandler<GetMealsByTeamManagementIdAndDateQuery, IEnumerable<Meal>>
{
    private readonly IMealRepository _repository;

    public GetMealByTeamManagementIdIdAndDateQueryHandle(IMealRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<Meal>> Handle(GetMealsByTeamManagementIdAndDateQuery request, CancellationToken cancellationToken)
    {
        return await _repository.GetMealsByTeamManagementIdAndDateAsync(request.TeamManagementId, request.Date);
    }
}
