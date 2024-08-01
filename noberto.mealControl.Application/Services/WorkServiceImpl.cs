using AutoMapper;
using MediatR;
using noberto.mealControl.Application.CQRS.WorkCQRS.Commands;
using noberto.mealControl.Application.CQRS.WorkCQRS.Queries;
using noberto.mealControl.Application.DTOs.WorkDTO;
using noberto.mealControl.Application.DTOs.WorkerDTO;
using noberto.mealControl.Application.Interfaces;

namespace noberto.mealControl.Application.Services;

public class WorkServiceImpl : IWorkService
{
    private readonly IMapper _mapper;
    private readonly IMediator _mediator;

    public WorkServiceImpl(IMapper mapper, IMediator mediator)
    {
        _mapper = mapper;
        _mediator = mediator;
    }

    public async Task CreateWorkAsync(CreateWorkDTO workDto)
    {
        var work = _mapper.Map<CreateWorkCommand>(workDto);
        await _mediator.Send(work);
    }
    public async Task<IEnumerable<WorkSelectDTO>> GetWorksByStateAsync(string state)
    {
        var work = new GetWorkByStateQuery(state);

        return _mapper.Map<IEnumerable<WorkSelectDTO>>(await _mediator.Send(work));
    }

    public async Task FinishWorkAsync(Guid workId)
    {
        var work = new FinishWorkCommand(workId);
        await _mediator.Send(work);
    }

    public async Task<IEnumerable<ReturnWorkDTO>> GetAllWorkAsync()
    {
        return _mapper.Map<IEnumerable<ReturnWorkDTO>>(
            await _mediator.Send(new GetAllWorksQuery()));
    }

    public async Task<ReturnWorkDTO> GetWorkByIdAsync(Guid workId)
    {
        return _mapper.Map<ReturnWorkDTO>(
            await _mediator.Send(new GetWorkByIdQuery(workId)));
    }
}
