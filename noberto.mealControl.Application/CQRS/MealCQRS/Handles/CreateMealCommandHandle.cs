using AutoMapper;
using MediatR;
using noberto.mealControl.Application.CQRS.MealCQRS.Commands;
using noberto.mealControl.Core.Entities;
using noberto.mealControl.Core.Repositories;
using System.Runtime.CompilerServices;

namespace noberto.mealControl.Application.CQRS.MealCQRS.Handles;

public class CreateMealCommandHandle
    : IRequestHandler<CreateMealCommand, Meal>
{
    private readonly IMealRepository _repository;
    private readonly IMapper _mapper;

    public CreateMealCommandHandle(IMealRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<Meal> Handle(CreateMealCommand request, CancellationToken cancellationToken)
    {
        var meal = _mapper.Map<Meal>(request);
        return await _repository.CreateMealAsync(meal);
    }
}
