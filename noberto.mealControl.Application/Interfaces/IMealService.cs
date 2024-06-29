using noberto.mealControl.Application.DTOs.MealDTO;

namespace noberto.mealControl.Application.Interfaces;

public interface IMealService
{
    Task CreateMealAsync(CreateMealDTO mealDto);
    Task<IEnumerable<ReturnMealDTO>> GetMealsByManagerIdAndDate(Guid managerId, DateOnly date);
    Task UpdateMealsAsync(IEnumerable<UpdateMealDTO> mealsDto);
}
