using Microsoft.EntityFrameworkCore;
using noberto.mealControl.Core.Entities;
using noberto.mealControl.Core.Enums.Impl;
using noberto.mealControl.Core.Exceptions;
using noberto.mealControl.Core.Repositories;
using noberto.mealControl.Infra.Database.Context;

namespace noberto.mealControl.Infra.Database.Repositories;

public class MealRepositoryImpl : IMealRepository
{
    private readonly MealControlDbContext _context;

    public MealRepositoryImpl(MealControlDbContext context)
    {
        _context = context;
    }

    public async Task<Meal> CreateMealAsync(Meal meal)
    {
        await _context.AddAsync(meal);
        await _context.SaveChangesAsync();
        return meal;
    }

    public async Task<Meal> GetMealByIdAsync(Guid mealId)
    {
        return await _context.Meals.FindAsync(mealId)
            ?? throw new EntityNotFoundException(TypesNotFoundEnum.MealNotFoundById.ToString());
    }

    public async Task<IEnumerable<Meal>> GetMealsByIdManagerAndDateAsync(Guid managerId, DateOnly date)
    {
        var meals = await _context.Meals
            .Where(meal => meal.Team.TeamManagement.ManagerId == managerId
            && meal.ScheduleLocalEvent.ScheduleEvent.MealDate == date)
            .ToListAsync();

        return meals.Count is not 0 ? meals
            : throw new EntityNotFoundException(TypesNotFoundEnum
                .MealNotFoundByManagerIdAndDate.ToString());
    }

    public async Task<Meal> UpdateMealsAsync(Meal meal)
    {
        var mealEntity = await _context.Meals.FindAsync(meal.Id);
        mealEntity.UpdateMeal(meal.Coffe, meal.Lunch, meal.Dinner);
        await _context.SaveChangesAsync();

        return meal;
    }
}
