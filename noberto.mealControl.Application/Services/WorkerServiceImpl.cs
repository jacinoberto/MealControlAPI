using AutoMapper;
using MediatR;
using noberto.mealControl.Application.CQRS.WorkerCQRS.Commands;
using noberto.mealControl.Application.CQRS.WorkerCQRS.Queries;
using noberto.mealControl.Application.DTOs.WorkerDTO;
using noberto.mealControl.Application.Interfaces;

namespace noberto.mealControl.Application.Services;

public class WorkerServiceImpl : IWorkerService
{
    private readonly IMapper _mapper;
    private readonly IMediator _mediator;

    public WorkerServiceImpl(IMapper mapper, IMediator mediator)
    {
        _mapper = mapper;
        _mediator = mediator;
    }

    public async Task<IEnumerable<ReturnWorkerDTO>> GetWorkersByRegistrationOrNameAsync(string registrationOrName)
    {
        var worker = new GetWorkerByRegistrationOrNameQuery(registrationOrName);
        return _mapper.Map<IEnumerable<ReturnWorkerDTO>>(await _mediator.Send(worker));
    }

    public async Task InactivateWorkerProfile(Guid workerId)
    {
        var worker = new InactivateWorkerProfileCommand(workerId);
        await _mediator.Send(worker);
    }
}
