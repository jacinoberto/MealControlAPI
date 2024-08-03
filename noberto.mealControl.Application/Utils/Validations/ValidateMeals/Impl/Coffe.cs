using MediatR;
using noberto.mealControl.Application.CQRS.MealCQRS.Commands;
using noberto.mealControl.Application.CQRS.MealCQRS.Queries;
using noberto.mealControl.Application.DTOs.MealDTO;
using noberto.mealControl.Application.DTOs.TeamDTO;
using noberto.mealControl.Application.Interfaces;
using noberto.mealControl.Application.Utils.Validations.ValidateDay;

namespace noberto.mealControl.Application.Utils.Validations.ValidateMeals.Impl;

public class Coffe : IValidateMeals<UpdateMealCoffeeDTO>
{
    private readonly IMediator _mediator;
    private readonly IValidateTerm _validateTerm;

    public Coffe(IMediator mediator, IValidateTerm validateTerm)
    {
        _mediator = mediator;
        _validateTerm = validateTerm;
    }

    public async Task Validate(UpdateMealCoffeeDTO coffeesDto)
    {
        var coffees = await _mediator.Send(new GetMealByDateQuery(coffeesDto.MealDate));
        var term = await _validateTerm.Validate(coffeesDto.MealDate);

        foreach (var coffeeUpdate in coffeesDto.Coffees)
        {
            foreach (var coffee in coffees)
            {
                if (coffeeUpdate.Coffee != coffee.Coffee)
                {
                    TimeSpan time = coffeesDto.MealDate.ToDateTime(new TimeOnly(7,0,0)) - DateTime.UtcNow;

                    if (time >= term)
                    {
                        await _mediator.Send(new UpdateMealCoffeeCommand(coffeeUpdate.Id, coffeeUpdate.Coffee));
                    }
                }
            }
        }
    }
}
