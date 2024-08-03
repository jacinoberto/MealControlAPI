using AutoMapper;
using MediatR;
using noberto.mealControl.Application.CQRS.MealCQRS.Commands;
using noberto.mealControl.Application.CQRS.MealCQRS.Queries;
using noberto.mealControl.Application.DTOs.MealDTO;
using noberto.mealControl.Application.Interfaces;
using noberto.mealControl.Application.Utils.Validations.ValidateDay;

namespace noberto.mealControl.Application.Utils.Validations.ValidateMeals.Impl;

public class Dinner : IValidateMeals<UpdateMealDinnerDTO, ReturnDinnersDTO>
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;
    private readonly IValidateTerm _validateTerm;

    public Dinner(IMediator mediator, IValidateTerm validateTerm, IMapper mapper)
    {
        _mediator = mediator;
        _validateTerm = validateTerm;
        _mapper = mapper;
    }

    public async Task<IEnumerable<ReturnDinnersDTO>> Validate(UpdateMealDinnerDTO dinnerDto)
    {
        ISet<ReturnDinnersDTO> dinnerList = new HashSet<ReturnDinnersDTO>();
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
                        dinnerList.Add(_mapper.Map<ReturnDinnersDTO>(
                            await _mediator.Send(new UpdateMealLunchCommand(
                                dinnerUpdate.Id, dinnerUpdate.Dinner))));
                    }
                }
            }
        }

        return dinnerList;
    }
}
