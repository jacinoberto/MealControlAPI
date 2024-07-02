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

    public async Task<Administrator> CreateAdministratorAsync(CreateAdministratorDTO administratorDto)
    {
        var administrator = _mapper.Map<CreateAdministratorCommand>(administratorDto);
        return await _mediator.Send(administrator);
    }

    public async Task RecoverAdministratorPasswordAsync(Guid administratorId, RecoverAdministratorPasswordDTO recoverPasswordDto)
    {
        var administrator = new RecoverAdministratorPasswordCommand(administratorId, recoverPasswordDto.User.Password);
        await _mediator.Send(administrator);
    }

    public async Task InactivateAdministratorProfileAsync(Guid administratorId)
    {
        var administrator = new InactivateAdministratorProfileCommand(administratorId);
        await _mediator.Send(administrator);
    }
}
