﻿using noberto.mealControl.Application.DTOs.MealDTO;

namespace noberto.mealControl.Application.Interfaces;

public interface IMealService
{
    Task CreateMealAsync(CreateMealDTO mealDto);
    Task<IEnumerable<ReturnMealDTO>> GetMealsByManagerIdAndDate(Guid managerId, DateOnly date);
    Task<IEnumerable<ReturnCoffesDTO>> GetMealCoffeesByDateAsync(DateOnly date);
    Task<IEnumerable<ReturnLunchesDTO>> GetMealLunchesByDateAsync(DateOnly date);
    Task<IEnumerable<ReturnDinnersDTO>> GetMealDinnersByDateAsync(DateOnly date);
    Task<IEnumerable<ReturnCoffesDTO>> GetCoffesByManagerIdAndDate(Guid managerId, DateOnly date);
    Task<IEnumerable<ReturnLunchesDTO>> GetLunchesByManagerIdAndDate(Guid managerId, DateOnly date);
    Task<IEnumerable<ReturnDinnersDTO>> GetDinnersByManagerIdAndDate(Guid managerId, DateOnly date);
    Task UpdateMealsAsync(IEnumerable<UpdateMealDTO> mealsDto);
    Task<IEnumerable<ReturnCoffesDTO>> UpdateMealCoffeeAsync(UpdateMealCoffeeDTO coffee);
    Task<IEnumerable<ReturnLunchesDTO>> UpdateMealLunchAsync(UpdateMealLunchDTO lunch);
    Task<IEnumerable<ReturnDinnersDTO>> UpdateMealDinnerAsync(UpdateMealDinnerDTO dinner);
}
