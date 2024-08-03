using MediatR;
using noberto.mealControl.Application.CQRS.MealCQRS.Commands;
using noberto.mealControl.Core.Entities;
using noberto.mealControl.Core.Repositories;

namespace noberto.mealControl.Application.CQRS.MealCQRS.Handles;

public class UpdateMealLunchCommandHandle
    : IRequestHandler<UpdateMealLunchCommand, Meal>
{
    private readonly IMealRepository _repository;

    public UpdateMealLunchCommandHandle(IMealRepository repository)
    {
        _repository = repository;
    }

    public async Task<Meal> Handle(UpdateMealLunchCommand request, CancellationToken cancellationToken)
    {
        return await _repository.UpdateMealLunchAsync(request.Id, request.Lunch);
    }
}
