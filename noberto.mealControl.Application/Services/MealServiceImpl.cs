using AutoMapper;
using MediatR;
using noberto.mealControl.Application.CQRS.MealCQRS.Commands;
using noberto.mealControl.Application.CQRS.MealCQRS.Queries;
using noberto.mealControl.Application.DTOs.MealDTO;
using noberto.mealControl.Application.Interfaces;
using noberto.mealControl.Application.Utils.Validations.ValidateMeals;

namespace noberto.mealControl.Application.Services;

public class MealServiceImpl : IMealService
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;
    private readonly IValidateMeals<UpdateMealCoffeeDTO> _validateCoffee;
    private readonly IValidateMeals<UpdateMealLunchDTO> _validateLunch;
    private readonly IValidateMeals<UpdateMealDinnerDTO> _validateDinner;

    public MealServiceImpl(IMediator mediator, IMapper mapper, IValidateMeals<UpdateMealCoffeeDTO> validateCoffee, IValidateMeals<UpdateMealLunchDTO> validateLunch, IValidateMeals<UpdateMealDinnerDTO> validateDinner)
    {
        _mediator = mediator;
        _mapper = mapper;
        _validateCoffee = validateCoffee;
        _validateLunch = validateLunch;
        _validateDinner = validateDinner;
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

    public async Task<IEnumerable<ReturnCoffesDTO>> GetMealCoffeesByDateAsync(DateOnly date)
    {
        return _mapper.Map<IEnumerable<ReturnCoffesDTO>>(
            await _mediator.Send(new GetMealByDateQuery(date)));
    }

    public async Task<IEnumerable<ReturnDinnersDTO>> GetMealDinnersByDateAsync(DateOnly date)
    {
        return _mapper.Map<IEnumerable<ReturnDinnersDTO>>(
            await _mediator.Send(new GetMealByDateQuery(date)));
    }

    public async Task<IEnumerable<ReturnLunchesDTO>> GetMealLunchesByDateAsync(DateOnly date)
    {
        return _mapper.Map<IEnumerable<ReturnLunchesDTO>>(
            await _mediator.Send(new GetMealByDateQuery(date)));
    }

    public Task<IEnumerable<ReturnMealDTO>> GetMealsByManagerIdAndDate(Guid managerId, DateOnly date)
    {
        throw new NotImplementedException();
    }

    public async Task UpdateMealCoffeeAsync(UpdateMealCoffeeDTO coffee)
    {
        await _validateCoffee.Validate(coffee);
    }

    public async Task UpdateMealDinnerAsync(UpdateMealDinnerDTO dinner)
    {
        await _validateDinner.Validate(dinner);
    }

    public async Task UpdateMealLunchAsync(UpdateMealLunchDTO lunch)
    {
        await _validateLunch.Validate(lunch);
    }

    public Task UpdateMealsAsync(IEnumerable<UpdateMealDTO> mealsDto)
    {
        throw new NotImplementedException();
    }
}
