using MediatR;
using noberto.mealControl.Application.CQRS.MealCQRS.Commands;
using noberto.mealControl.Application.CQRS.MealCQRS.Queries;
using noberto.mealControl.Application.DTOs.MealDTO;
using noberto.mealControl.Application.Interfaces;
using noberto.mealControl.Application.Utils.Validations.ValidateDay;

namespace noberto.mealControl.Application.Utils.Validations.ValidateMeals.Impl;

public class Lunch : IValidateMeals<UpdateMealLunchDTO>
{
    private readonly IMediator _mediator;
    private readonly IValidateTerm _validateTerm;

    public Lunch(IMediator mediator, IValidateTerm validateTerm)
    {
        _mediator = mediator;
        _validateTerm = validateTerm;
    }

    public async Task Validate(UpdateMealLunchDTO lunchesDto)
    {
        var lunches = await _mediator.Send(new GetMealByDateQuery(lunchesDto.MealDate));
        var term = await _validateTerm.Validate(lunchesDto.MealDate);

        foreach (var lunchUpdate in lunchesDto.Lunches)
        {
            foreach (var lunch in lunches)
            {
                if (lunchUpdate.Lunch != lunch.Lunch)
                {
                    TimeSpan time = lunchesDto.MealDate.ToDateTime(new TimeOnly(12, 0, 0)) - DateTime.UtcNow;

                    if (time >= term)
                    {
                        await _mediator.Send(new UpdateMealLunchCommand(lunchUpdate.Id, lunchUpdate.Lunch));
                    }
                }
            }
        }
    }
}
