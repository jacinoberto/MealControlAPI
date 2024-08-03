using MediatR;
using noberto.mealControl.Application.CQRS.MealCQRS.Commands;
using noberto.mealControl.Application.CQRS.MealCQRS.Queries;
using noberto.mealControl.Application.DTOs.MealDTO;
using noberto.mealControl.Application.Interfaces;
using noberto.mealControl.Application.Utils.Validations.ValidateDay;

namespace noberto.mealControl.Application.Utils.Validations.ValidateMeals.Impl;

public class Dinner : IValidateMeals<UpdateMealDinnerDTO>
{
    private readonly IMediator _mediator;
    private readonly IValidateTerm _validateTerm;

    public Dinner(IMediator mediator, IValidateTerm validateTerm)
    {
        _mediator = mediator;
        _validateTerm = validateTerm;
    }

    public async Task Validate(UpdateMealDinnerDTO dinnerDto)
    {
        var dinners = await _mediator.Send(new GetMealByDateQuery(dinnerDto.MealDate));
        var term = await _validateTerm.Validate(dinnerDto.MealDate);

        foreach (var dinnerUpdate in dinnerDto.Dinners)
        {
            foreach (var dinner in dinners)
            {
                if (dinnerUpdate.Dinner != dinner.Dinner)
                {
                    TimeSpan time = dinnerDto.MealDate.ToDateTime(new TimeOnly(19, 0, 0)) - DateTime.UtcNow;

                    if (time >= term)
                    {
                        await _mediator.Send(new UpdateMealLunchCommand(dinnerUpdate.Id, dinnerUpdate.Dinner));
                    }
                }
            }
        }
    }
}
