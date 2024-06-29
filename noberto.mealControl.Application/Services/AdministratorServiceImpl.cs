using AutoMapper;
using MediatR;
using noberto.mealControl.Application.CQRS.AdministratorCQRS.Commands;
using noberto.mealControl.Application.DTOs.AdministratorDTO;
using noberto.mealControl.Application.Interfaces;
using noberto.mealControl.Core.Entities;

namespace noberto.mealControl.Application.Services;

public class AdministratorServiceImpl : IAdministratorService
{
    private readonly IMapper _mapper;
    private readonly IMediator _mediator;

    public AdministratorServiceImpl(IMapper mapper, IMediator mediator)
    {
        _mapper = mapper;
        _mediator = mediator;
    }

    public async Task CreateAdministratorAsync(CreateAdministratorDTO administratorDto)
    {
        var administrator = _mapper.Map<CreateManagerCommand>(administratorDto);
        await _mediator.Send(administrator);
    }

    public async Task RecoverAdministratorPassword(Guid administratorId, string password)
    {
        var administrator = new RecoverAdministratorPasswordCommand(administratorId, password);
        await _mediator.Send(administrator);
    }

    public async Task InactivateAdministratorProfile(Guid administratorId)
    {
        var administrator = new InactivateAdministratorProfileCommand(administratorId);
        await _mediator.Send(administrator);
    }
}
