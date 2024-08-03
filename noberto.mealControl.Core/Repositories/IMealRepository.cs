using noberto.mealControl.Core.Entities;

namespace noberto.mealControl.Core.Repositories;

public interface IMealRepository
{
    Task<Meal> CreateMealAsync(Meal meal);
    Task<Meal> GetMealByIdAsync(Guid mealId);
    Task<IEnumerable<Meal>> GetMealByDate(DateOnly date);
    Task<IEnumerable<Meal>> GetMealsByTeamManagementIdAndDateAsync(Guid managerId, DateOnly date);
    Task<IEnumerable<Meal>> GetMealsByStartDateAndClosingDateAndManagerIdAsync(DateOnly startDate, DateOnly closingDate, Guid managerId);
    Task<Meal> UpdateMealsAsync(Meal meal);
    Task<Meal> UpdateMealCoffeeAsync(Guid id, bool coffee);
    Task<Meal> UpdateMealLunchAsync(Guid id, bool lunch);
    Task<Meal> UpdateMealDinnerAsync(Guid id, bool dinner);
}
