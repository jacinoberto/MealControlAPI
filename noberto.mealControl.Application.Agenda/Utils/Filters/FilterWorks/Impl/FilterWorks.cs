using noberto.mealControl.Application.DTOs.WorkDTO;
using noberto.mealControl.Application.Interfaces;
using noberto.mealControl.Core.Entities;

namespace noberto.mealControl.Application.BackgroundService.Utils.Filters.FilterWorks.Impl;

public class FilterWorks : IFilterWorks
{
    private readonly IScheduleLocalEventService _service;

    public FilterWorks(IScheduleLocalEventService service)
    {
        _service = service;
    }

    public async Task<ISet<WorkIdDTO>> Filter(DateOnly date, ICollection<Work> works,
        ISet<WorkIdDTO> pendingWorks)
    {
        var scheduleLocalEvents = await _service.GetScheduleLocalEventByDateAsync(date);

        foreach (var work in works)
        {
            foreach (var scheduleLocalEvent in scheduleLocalEvents)
            {
                if (scheduleLocalEvent.WorkId != work.Id)
                    pendingWorks.Add(new WorkIdDTO(work.Id));
            }
        }

        return pendingWorks;
    }
}
