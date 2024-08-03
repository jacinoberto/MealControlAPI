using AutoMapper;
using MediatR;
using noberto.mealControl.Application.CQRS.MealCQRS.Commands;
using noberto.mealControl.Application.CQRS.MealCQRS.Queries;
using noberto.mealControl.Application.DTOs.MealDTO;
using noberto.mealControl.Application.DTOs.TeamDTO;
using noberto.mealControl.Application.Interfaces;
using noberto.mealControl.Application.Utils.Validations.ValidateDay;

namespace noberto.mealControl.Application.Utils.Validations.ValidateMeals.Impl;

public class Coffe : IValidateMeals<UpdateMealCoffeeDTO, ReturnCoffesDTO>
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;
    private readonly IValidateTerm _validateTerm;

    public Coffe(IMediator mediator, IValidateTerm validateTerm, IMapper mapper)
    {
        _mediator = mediator;
        _validateTerm = validateTerm;
        _mapper = mapper;
    }

    public async Task<IEnumerable<ReturnCoffesDTO>> Validate(UpdateMealCoffeeDTO coffeesDto)
    {
        ISet<ReturnCoffesDTO> coffeeList = new HashSet<ReturnCoffesDTO>();
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
                        coffeeList.Add(_mapper.Map<ReturnCoffesDTO>(
                            await _mediator.Send(new UpdateMealCoffeeCommand(
                                coffeeUpdate.Id, coffeeUpdate.Coffee))));

                        var teste = coffeeList.Count();
                    }
                }
            }
        }

        return coffeeList;
    }
}
