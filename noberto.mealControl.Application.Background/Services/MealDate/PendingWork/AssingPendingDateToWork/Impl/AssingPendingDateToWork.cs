using AutoMapper;
using noberto.mealControl.Application.Background.Services.MealDate.PendingWork.AssingDateToWork;
using noberto.mealControl.Application.Background.Utils.Filters.FilterWorks;
using noberto.mealControl.Application.DTOs.ScheduleEventDTO;
using noberto.mealControl.Application.DTOs.WorkDTO;
using noberto.mealControl.Application.Interfaces;
using noberto.mealControl.Core.Entities;

namespace noberto.mealControl.Application.Background.Services.MealDate.PendingWork.AssingPendingDateToWork.Impl;

public class AssingPendingDateToWork : IAssingPendingDateToWork
{
    private readonly IScheduleEventService _scheduleService;
    private readonly IFilterWorks _filterWork;
    private readonly IAssingDateToWork _assingDateToWork;
    private readonly IMapper _mapper;

    public AssingPendingDateToWork(IScheduleEventService scheduleService, IMapper mapper, IFilterWorks filterWork, IAssingDateToWork assingDateToWork)
    {
        _scheduleService = scheduleService;
        _mapper = mapper;
        _filterWork = filterWork;
        _assingDateToWork = assingDateToWork;
    }

    public async Task ToAssing(ScheduleEvent scheduleEvent, DateOnly date, ICollection<Work> works,
        ICollection<ScheduleLocalEvent> scheduleLocalEvents)
    {
        if (scheduleEvent is not null
            && scheduleEvent.Atypical is true
            && works.Count != scheduleLocalEvents.Count)
        {
            ISet<WorkIdDTO> pendingsWorks = new HashSet<WorkIdDTO>();

            var schedule = await _scheduleService.CreateScheduleEventAsync(
                _mapper.Map<CreateScheduleEventDTO>(new SchedulePendingEventDTO(date, false)));

            var filterWorks = await _filterWork.Filter(date, works, pendingsWorks);
            await _assingDateToWork.ToAssing(filterWorks, _mapper.Map<ScheduleEvent>(schedule));
        }
    }
}
