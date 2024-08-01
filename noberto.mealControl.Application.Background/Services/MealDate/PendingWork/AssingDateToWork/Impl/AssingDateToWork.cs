using AutoMapper;
using MediatR;
using noberto.mealControl.Application.DTOs.ScheduleLocalEventDTO;
using noberto.mealControl.Application.DTOs.WorkDTO;
using noberto.mealControl.Application.Interfaces;
using noberto.mealControl.Core.Entities;
using noberto.mealControl.Core.Repositories;

namespace noberto.mealControl.Application.Background.Services.MealDate.PendingWork.AssingDateToWork.Impl;

public class AssingDateToWork : IAssingDateToWork
{
    private readonly IScheduleLocalEventService _scheduleLocalEventService;

    public AssingDateToWork(IScheduleLocalEventService scheduleLocalEventService)
    {
        _scheduleLocalEventService = scheduleLocalEventService;
    }

    public async Task ToAssing(ISet<WorkIdDTO> works, ScheduleEvent scheduleEvent)
    {
        foreach (var work in works)
        {
            var scheduleLocalEvents = await _scheduleLocalEventService
                .GetScheduleLocalEventByWorkIdAndMealDateAndAtypicalAsync(work.Id, scheduleEvent.MealDate, scheduleEvent.Atypical);

            if (scheduleLocalEvents.Count is 0)
                await _scheduleLocalEventService.CreateScheduleLocalEventAsync(
                    new CreateScheduleLocalEventDTO(null, scheduleEvent.Id, work.Id));
        }
    }
}
