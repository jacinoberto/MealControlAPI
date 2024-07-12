using AutoMapper;
using MediatR;
using noberto.mealControl.Application.CQRS.ScheduleEventCQRS.Commands;
using noberto.mealControl.Application.CQRS.ScheduleEventCQRS.Queries;
using noberto.mealControl.Application.DTOs.ScheduleEventDTO;
using noberto.mealControl.Application.Interfaces;
using noberto.mealControl.Core.Entities;

namespace noberto.mealControl.Application.Services;

public class ScheduleEventServiceImpl : IScheduleEventService
{
    private readonly IMapper _mapper;
    private readonly IMediator _mediator;

    public ScheduleEventServiceImpl(IMapper mapper, IMediator mediator)
    {
        _mapper = mapper;
        _mediator = mediator;
    }

    public async Task<ReturnScheduleEventDTO> CreateScheduleEventAsync(CreateScheduleEventDTO scheduleEventDto)
    {
        var scheduleEvent = _mapper.Map<CreateScheduleEventCommand>(scheduleEventDto);
        return _mapper.Map<ReturnScheduleEventDTO>(await _mediator.Send(scheduleEvent));
    }

    public async Task<ReturnScheduleEventDTO?> GetScheduleEventByDateAsync(DateOnly date)
    {
        var schedule = _mapper.Map<ReturnScheduleEventDTO>(await _mediator.Send(
            new GetScheduleEventByDateQuery(date)));
        return schedule is not null ? schedule
            : null;
    }
}
