using noberto.mealControl.Core.Entities;
using noberto.mealControl.Core.Repositories;
using noberto.mealControl.Infra.Database.Context;

namespace noberto.mealControl.Infra.Database.Repositories;

public class ScheduleEventRepositoryImpl : IScheduleEventRepository
{
    private readonly MealControlDbContext _context;

    public ScheduleEventRepositoryImpl(MealControlDbContext context)
    {
        _context = context;
    }

    public async Task<ScheduleEvent> CreateScheduleEventAsync(ScheduleEvent scheduleEvent)
    {
        await _context.AddAsync(scheduleEvent);
        await _context.SaveChangesAsync();
        return scheduleEvent;
    }
}
