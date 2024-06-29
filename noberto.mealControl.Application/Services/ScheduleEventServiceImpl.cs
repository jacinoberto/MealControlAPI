using AutoMapper;
using MediatR;
using noberto.mealControl.Application.CQRS.ScheduleEventCQRS.Commands;
using noberto.mealControl.Application.DTOs.ScheduleEventDTO;
using noberto.mealControl.Application.Interfaces;

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

    public async Task CreateScheduleEventAsync(CreateScheduleEventDTO scheduleEventDto)
    {
        var scheduleEvent = _mapper.Map<CreateScheduleEventCommand>(scheduleEventDto);
        await _mediator.Send(scheduleEvent);
    }
}
