using MediatR;
using noberto.mealControl.Application.CQRS.MealCQRS.Commands;
using noberto.mealControl.Core.Entities;
using noberto.mealControl.Core.Repositories;

namespace noberto.mealControl.Application.CQRS.MealCQRS.Handles;

public class UpdateMealCoffeeCommandHandle
    : IRequestHandler<UpdateMealCoffeeCommand, Meal>
{
    private readonly IMealRepository _repository;

    public UpdateMealCoffeeCommandHandle(IMealRepository repository)
    {
        _repository = repository;
    }

    public async Task<Meal> Handle(UpdateMealCoffeeCommand request, CancellationToken cancellationToken)
    {
        return await _repository.UpdateMealCoffeeAsync(request.Id, request.Coffee);
    }
}
