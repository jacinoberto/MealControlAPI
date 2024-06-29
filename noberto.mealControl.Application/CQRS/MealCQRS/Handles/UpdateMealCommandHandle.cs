using AutoMapper;
using MediatR;
using noberto.mealControl.Application.CQRS.MealCQRS.Commands;
using noberto.mealControl.Core.Entities;
using noberto.mealControl.Core.Repositories;

namespace noberto.mealControl.Application.CQRS.MealCQRS.Handles;

public class UpdateMealCommandHandle
    : IRequestHandler<UpdateMealsCommand, Meal>
{
    private readonly IMealRepository _repository;
    private readonly IMapper _mapper;

    public UpdateMealCommandHandle(IMealRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<Meal> Handle(UpdateMealsCommand request, CancellationToken cancellationToken)
    {
        var meal = _mapper.Map<Meal>(request);
        return await _repository.UpdateMealsAsync(meal);
    }
}
