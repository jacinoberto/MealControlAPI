using AutoMapper;
using MediatR;
using noberto.mealControl.Application.DTOs.ScheduleLocalEventDTO;
using noberto.mealControl.Application.Interfaces;

namespace noberto.mealControl.Application.Services;

public class ScheduleLocalEventServiceImpl : IScheduleLocalEventService
{
    private readonly IMapper _mapper;
    private readonly IMediator _mediator;

    public ScheduleLocalEventServiceImpl(IMapper mapper, IMediator mediator)
    {
        _mapper = mapper;
        _mediator = mediator;
    }

    public async Task CreateScheduleLocalEventAsync(CreateScheduleLocalEventDTO scheduleLocalEventDto)
    {
        var scheduleLocalEvent = _mapper.Map<CreateScheduleLocalEventDTO>(scheduleLocalEventDto);
        await _mediator.Send(scheduleLocalEvent);
    }
}
