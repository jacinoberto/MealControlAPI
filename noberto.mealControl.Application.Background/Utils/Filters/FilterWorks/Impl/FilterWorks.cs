using noberto.mealControl.Application.DTOs.WorkDTO;
using noberto.mealControl.Application.Interfaces;
using noberto.mealControl.Core.Entities;

namespace noberto.mealControl.Application.Background.Utils.Filters.FilterWorks.Impl;

public class FilterWorks : IFilterWorks
{
    private readonly IScheduleLocalEventService _service;
    private readonly IWorkService _workService;

    public FilterWorks(IScheduleLocalEventService service, IWorkService workService)
    {
        _service = service;
        _workService = workService;
    }

    public async Task<ISet<WorkIdDTO>> Filter(DateOnly date, ICollection<Work> works,
        ISet<WorkIdDTO> pendingWorks)
    {
        var scheduleLocalEvents = await _service.GetScheduleLocalEventByDateAsync(date);

        foreach (var work in works)
        {
            foreach (var scheduleLocalEvent in scheduleLocalEvents)
            {
                var result = await _service.GetScheduleLocalEventByScheduleEventIdAsync(scheduleLocalEvent.ScheduleEventId);

                if (result is null
                    && scheduleLocalEvent.WorkId != work.Id)
                    pendingWorks.Add(new WorkIdDTO(work.Id));
            }                
        }

        return pendingWorks;
    }
}
