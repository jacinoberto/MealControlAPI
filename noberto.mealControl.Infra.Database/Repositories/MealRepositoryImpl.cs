using Microsoft.EntityFrameworkCore;
using noberto.mealControl.Application.Utils.Validations.ValidateMeals.Impl;
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

    public async Task<IEnumerable<Meal>> GetMealByDate(DateOnly date)
    {
        return await _context.Meals
            .Where(meal => meal.ScheduleLocalEvent.ScheduleEvent.MealDate == date)
            .ToListAsync();
    }

    public async Task<Meal> GetMealByIdAsync(Guid mealId)
    {
        return await _context.Meals.FindAsync(mealId)
            ?? throw new EntityNotFoundException(TypesNotFoundEnum.MealNotFoundById.ToString());
    }

    public async Task<IEnumerable<Meal>> GetMealsByTeamManagementIdAndDateAsync(Guid teamManagementId, DateOnly date)
    {
        var meals = await _context.Meals
            .Where(meal => meal.Team.TeamManagementId == teamManagementId
            && meal.ScheduleLocalEvent.ScheduleEvent.MealDate == date)
            .Include(meal => meal.Team.Worker)
            .ToListAsync();

        return meals.Count is not 0 ? meals
            : throw new EntityNotFoundException(TypesNotFoundEnum
                .MealNotFoundByManagerIdAndDate.ToString());
    }

    public async Task<IEnumerable<Meal>> GetMealsByStartDateAndClosingDateAndManagerIdAsync(DateOnly startDate, DateOnly closingDate, Guid managerId)
    {
        return await _context.Meals
            .Where(meal => meal.ScheduleLocalEvent.ScheduleEvent.MealDate >= startDate
            && meal.ScheduleLocalEvent.ScheduleEvent.MealDate <= closingDate
            && meal.Team.TeamManagement.ManagerId == managerId)
            .ToListAsync();
    }

    public async Task<Meal> UpdateMealCoffeeAsync(Guid id, bool coffee)
    {
        var meal = await _context.Meals
            .Include(meal => meal.Team.Worker)
            .FirstOrDefaultAsync(meal => meal.Id == id);

        meal.UpdateCoffee(coffee);
        await _context.SaveChangesAsync();

        return meal;
    }

    public async Task<Meal> UpdateMealDinnerAsync(Guid id, bool dinner)
    {
        var meal = await _context.Meals
            .Include(meal => meal.Team.Worker)
            .FirstOrDefaultAsync(meal => meal.Id == id);

        meal.UpdateDinner(dinner);
        await _context.SaveChangesAsync();

        return meal;
    }

    public async Task<Meal> UpdateMealLunchAsync(Guid id, bool lunch)
    {
        var meal = await _context.Meals
            .Include(meal => meal.Team.Worker)
            .FirstOrDefaultAsync(meal => meal.Id == id);

        meal.UpdateLunch(lunch);
        await _context.SaveChangesAsync();

        return meal;
    }

    public async Task<Meal> UpdateMealsAsync(Meal meal)
    {
        var mealEntity = await _context.Meals.FindAsync(meal.Id);
        //mealEntity.UpdateMeal(meal.Coffe, meal.Lunch, meal.Dinner);
        await _context.SaveChangesAsync();

        return meal;
    }
}
