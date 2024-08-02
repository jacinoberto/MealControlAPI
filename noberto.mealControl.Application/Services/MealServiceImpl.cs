using AutoMapper;
using MediatR;
using noberto.mealControl.Application.CQRS.MealCQRS.Commands;
using noberto.mealControl.Application.CQRS.MealCQRS.Queries;
using noberto.mealControl.Application.DTOs.MealDTO;
using noberto.mealControl.Application.Interfaces;

namespace noberto.mealControl.Application.Services;

public class MealServiceImpl : IMealService
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    public MealServiceImpl(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    public async Task CreateMealAsync(CreateMealDTO mealDto)
    {

        var createMeal = _mapper.Map<CreateMealCommand>(mealDto);
        await _mediator.Send(createMeal);
    }

    public async Task<IEnumerable<ReturnCoffesDTO>> GetCoffesByManagerIdAndDate(Guid managerId, DateOnly date)
    {
        return _mapper.Map<IEnumerable<ReturnCoffesDTO>>(
            await _mediator.Send(new GetMealsByManagerIdAndDateQuery(managerId, date)));
    }

    public async Task<IEnumerable<ReturnDinnersDTO>> GetDinnersByManagerIdAndDate(Guid managerId, DateOnly date)
    {
        return _mapper.Map<IEnumerable<ReturnDinnersDTO>>(
            await _mediator.Send(new GetMealsByManagerIdAndDateQuery(managerId, date)));
    }

    public async Task<IEnumerable<ReturnLunchesDTO>> GetLunchesByManagerIdAndDate(Guid managerId, DateOnly date)
    {
        return _mapper.Map<IEnumerable<ReturnLunchesDTO>>(
            await _mediator.Send(new GetMealsByManagerIdAndDateQuery(managerId, date)));
    }

    public Task<IEnumerable<ReturnMealDTO>> GetMealsByManagerIdAndDate(Guid managerId, DateOnly date)
    {
        throw new NotImplementedException();
    }

    public Task UpdateMealsAsync(IEnumerable<UpdateMealDTO> mealsDto)
    {
        throw new NotImplementedException();
    }
}
