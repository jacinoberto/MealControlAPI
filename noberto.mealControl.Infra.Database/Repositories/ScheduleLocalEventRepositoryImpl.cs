using noberto.mealControl.Core.Entities;
using noberto.mealControl.Core.Repositories;
using noberto.mealControl.Infra.Database.Context;

namespace noberto.mealControl.Infra.Database.Repositories;

public class ScheduleLocalEventRepositoryImpl : IScheduleLocalEventRepository
{
    private readonly MealControlDbContext _context;

    public ScheduleLocalEventRepositoryImpl(MealControlDbContext context)
    {
        _context = context;
    }

    public async Task<ScheduleLocalEvent> CreateScheduleLocalEventAsync(ScheduleLocalEvent scheduleLocalEvent)
    {
        await _context.AddAsync(scheduleLocalEvent);
        await _context.SaveChangesAsync();
        return scheduleLocalEvent;
    }
}
