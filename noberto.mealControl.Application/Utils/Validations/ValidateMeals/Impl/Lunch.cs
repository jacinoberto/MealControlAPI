using AutoMapper;
using MediatR;
using noberto.mealControl.Application.CQRS.MealCQRS.Commands;
using noberto.mealControl.Application.CQRS.MealCQRS.Queries;
using noberto.mealControl.Application.DTOs.MealDTO;
using noberto.mealControl.Application.Interfaces;
using noberto.mealControl.Application.Utils.Validations.ValidateDay;

namespace noberto.mealControl.Application.Utils.Validations.ValidateMeals.Impl;

public class Lunch : IValidateMeals<UpdateMealLunchDTO, ReturnLunchesDTO>
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;
    private readonly IValidateTerm _validateTerm;

    public Lunch(IMediator mediator, IValidateTerm validateTerm, IMapper mapper)
    {
        _mediator = mediator;
        _validateTerm = validateTerm;
        _mapper = mapper;
    }

    public async Task<IEnumerable<ReturnLunchesDTO>> Validate(UpdateMealLunchDTO lunchesDto)
    {
        ISet<ReturnLunchesDTO> lunchList = new HashSet<ReturnLunchesDTO>();
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
                        lunchList.Add(_mapper.Map<ReturnLunchesDTO>(
                            await _mediator.Send(new UpdateMealLunchCommand(
                                lunchUpdate.Id, lunchUpdate.Lunch))));
                    }
                }
            }
        }

        return lunchList;
    }
}
