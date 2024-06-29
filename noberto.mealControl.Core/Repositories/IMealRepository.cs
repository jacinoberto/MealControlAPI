using noberto.mealControl.Core.Entities;

namespace noberto.mealControl.Core.Repositories;

public interface IMealRepository
{
    Task<Meal> CreateMealAsync(Meal meal);
    Task<Meal> GetMealByIdAsync(Guid mealId);
    Task<IEnumerable<Meal>> GetMealsByIdManagerAndDateAsync(Guid managerId, DateOnly date);
    Task<Meal> UpdateMealsAsync(Meal meal);
}
