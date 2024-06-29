using AutoMapper;
using MediatR;
using noberto.mealControl.Application.CQRS.ManagerCQRS.Commands;
using noberto.mealControl.Application.CQRS.ManagerCQRS.Handles;
using noberto.mealControl.Application.CQRS.ManagerCQRS.Queries;
using noberto.mealControl.Application.DTOs.ManagerDTO;
using noberto.mealControl.Application.Interfaces;
using System.Globalization;

namespace noberto.mealControl.Application.Services;

public class ManagerServiceImpl : IManagerService
{
    private readonly IMapper _mapper;
    private readonly IMediator _mediator;

    public ManagerServiceImpl(IMapper mapper, IMediator mediator)
    {
        _mapper = mapper;
        _mediator = mediator;
    }

    public async Task CreateManagerAsync(CreateManagerDTO managerDto)
    {
        var manager = _mapper.Map<CreateManagerCommnad>(managerDto);
        await _mediator.Send(manager);
    }

    public async Task<IEnumerable<ManagerSelectDTO>> GetManagersByRegistrationOrNameOrEmailAsync(string registrationOrNameOrEmail, string state)
    {
        var managers = new GetMangerByRegistrationOrNameOrEmailQuery(registrationOrNameOrEmail, state);
        return _mapper.Map<IEnumerable<ManagerSelectDTO>>(await _mediator.Send(managers));
    }

    public async Task<IEnumerable<ManagerSelectDTO>> GetManagersByStateAsync(string state)
    {
        var managers = new GetManagerByStateQuery(state);
        return _mapper.Map<IEnumerable<ManagerSelectDTO>>(await _mediator.Send(state));
    }

    public async Task InactivateManagerProfile(Guid managerId)
    {
        var manager = new InactivateManagerProfileCommand(managerId);
        await _mediator.Send(manager);
    }
}
