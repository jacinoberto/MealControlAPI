using Microsoft.EntityFrameworkCore;
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

    public async Task<ICollection<ScheduleLocalEvent>> GetScheduleLocalEventByDate(DateOnly date)
    {
        return await _context.ScheduleLocalEvents
            .Where(schedule => schedule.ScheduleEvent.MealDate == date)
            .ToListAsync();
    }

    public async Task<ICollection<ScheduleLocalEvent>> GetScheduleLocalEventByIdAndDateAndDayAtypical(Guid workId, DateOnly mealDate, bool atypicalDay)
    {
        return await _context.ScheduleLocalEvents
            .Where(schedule => schedule.WorkId == workId
            && schedule.ScheduleEvent.MealDate == mealDate
            && schedule.ScheduleEvent.Atypical == true)
            .ToListAsync(); ;
    }

    public async Task<ScheduleLocalEvent?> GetScheduleLocalEventByScheduleEventId(Guid scheduleEventId)
    {
        return await _context.ScheduleLocalEvents
            .FirstOrDefaultAsync(scheduleLocalEvent => scheduleLocalEvent.ScheduleEventId == scheduleEventId);
    }

    public async Task<ScheduleLocalEvent?> GetScheduleLocalEventByWorkId(Guid workId)
    {
        return await _context.ScheduleLocalEvents
            .FirstOrDefaultAsync(schedule => schedule.WorkId == workId);
    }

    public async Task<IEnumerable<ScheduleLocalEvent>> GetScheduleLocalEventsByDay()
    {
        return await _context.ScheduleLocalEvents
            .Where(schedule => schedule.ScheduleEvent.MealDate > DateOnly.FromDateTime(DateTime.Today)
            && schedule.ScheduleEvent.MealDate < schedule.ScheduleEvent.MealDate.AddDays(7))
            .Include(schedule => schedule.ScheduleEvent)
            .Include(schedule => schedule.Work)
            .ToListAsync();
    }
}
