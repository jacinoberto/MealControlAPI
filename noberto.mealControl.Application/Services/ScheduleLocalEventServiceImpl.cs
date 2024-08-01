using AutoMapper;
using MediatR;
using noberto.mealControl.Application.CQRS.ScheduleLocalEventCQRS.Commands;
using noberto.mealControl.Application.CQRS.ScheduleLocalEventCQRS.Queries;
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

    public async Task<ReturnScheduleLocalEventDTO> CreateScheduleLocalEventAsync(CreateScheduleLocalEventDTO scheduleLocalEventDto)
    {
        var scheduleLocalEvent = _mapper.Map<CreateScheduleLocalEventCommand>(scheduleLocalEventDto);
        return _mapper.Map<ReturnScheduleLocalEventDTO>(await _mediator.Send(scheduleLocalEvent));
    }

    public async Task<ICollection<ReturnScheduleLocalEventDTO>> GetScheduleLocalEventByDateAsync(DateOnly date)
    {
        var scheduleLocalEvent = new GetScheduleLocalEventByDateQuery(date);
        return _mapper.Map<ICollection<ReturnScheduleLocalEventDTO>>(
            await _mediator.Send(scheduleLocalEvent));
    }

    public async Task<IEnumerable<ReturnScheduleLocalEventDTO>> GetScheduleLocalEventByDay()
    {
        return _mapper.Map<IEnumerable<ReturnScheduleLocalEventDTO>>(
            await _mediator.Send(new GetScheduleLocalEventByDayQuery()));
    }

    public async Task<ReturnScheduleLocalEventDTO> GetScheduleLocalEventByScheduleEventIdAsync(Guid scheduleEventId)
    {
        return _mapper.Map<ReturnScheduleLocalEventDTO>(
            await _mediator.Send(new GetScheduleLocalEventByScheduleEventIdQuery(scheduleEventId)));
    }

    public async Task<ICollection<ReturnScheduleLocalEventDTO>> GetScheduleLocalEventByWorkIdAndMealDateAndAtypicalAsync(Guid workId, DateOnly mealDate, bool atypical)
    {
        return _mapper.Map<ICollection<ReturnScheduleLocalEventDTO>>(
            await _mediator.Send(new GetSchduleLocalEventByWorkIdAndMealDateAndAtypicalQuery(workId, mealDate, atypical)));
    }
}
