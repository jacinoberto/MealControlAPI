using MediatR;
using noberto.mealControl.Application.CQRS.MealCQRS.Commands;
using noberto.mealControl.Core.Entities;
using noberto.mealControl.Core.Repositories;

namespace noberto.mealControl.Application.CQRS.MealCQRS.Handles;

public class UpdateMealDinnerCommandHandle
    : IRequestHandler<UpdateMealDinnerCommand, Meal>
{
    private readonly IMealRepository _repository;

    public UpdateMealDinnerCommandHandle(IMealRepository repository)
    {
        _repository = repository;
    }

    public async Task<Meal> Handle(UpdateMealDinnerCommand request, CancellationToken cancellationToken)
    {
        return await _repository.UpdateMealDinnerAsync(request.Id, request.Dinner);
    }
}
