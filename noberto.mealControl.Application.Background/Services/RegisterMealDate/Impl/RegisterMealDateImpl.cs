
using AutoMapper;
using noberto.mealControl.Application.Background.Services.MealDate.PendingWork.AssingPendingDateToWork;
using noberto.mealControl.Application.Background.Services.MealDate.PendingWork.AssingPendingWorksToDate;
using noberto.mealControl.Application.Interfaces;
using noberto.mealControl.Core.Entities;
using noberto.mealControl.Core.Repositories;

namespace noberto.mealControl.Application.Background.Services.RegisterMealDate.Impl;

public class RegisterMealDateImpl : IRegisterMealDate
{
    private readonly IScheduleLocalEventService _scheduleLocalEventService;
    private readonly IScheduleEventService _scheduleEventService;
    private readonly IWorkRepository _workRepository;
    private readonly IAssingPendingDateToWork _assingDateToWork;
    private readonly IAssingPendingWorksToDate _assingWorkToDate;
    private readonly IMapper _mapper;

    public RegisterMealDateImpl(IScheduleLocalEventService scheduleLocalEventService,
        IScheduleEventService scheduleEventService, IWorkRepository workRepository,
        IAssingPendingDateToWork assingDateToWork, IAssingPendingWorksToDate assingWorkToDate, IMapper mapper)
    {
        _scheduleLocalEventService = scheduleLocalEventService;
        _scheduleEventService = scheduleEventService;
        _workRepository = workRepository;
        _assingDateToWork = assingDateToWork;
        _assingWorkToDate = assingWorkToDate;
        _mapper = mapper;
    }

    public async Task Register()
    {
        DateOnly day = DateOnly.FromDateTime(DateTime.Today).AddDays(3);

        if (DateTime.Today.DayOfWeek == DayOfWeek.Thursday)
        {
            for (int i = 1; i <= 7; i++)
            {
                day = day.AddDays(1);

                var scheduleEvent = _mapper.Map<ScheduleEvent>(await _scheduleEventService.GetScheduleEventByDateAsync(day));
                var works = await _workRepository.GetAllWorksAsync();
                var shceduleLocalEvents = _mapper.Map<ICollection<ScheduleLocalEvent>>(await _scheduleLocalEventService.GetScheduleLocalEventByDateAsync(day));

                await _assingWorkToDate.ToAssing(scheduleEvent, day);
                await _assingDateToWork.ToAssing(scheduleEvent, day, works, shceduleLocalEvents);
            }
        }            
    }
}
