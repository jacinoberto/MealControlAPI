using AutoMapper;
using MediatR;
using noberto.mealControl.Application.CQRS.TeamManagementCQRS.Commands;
using noberto.mealControl.Application.CQRS.TeamManagementCQRS.Queries;
using noberto.mealControl.Application.DTOs.TeamManagement;
using noberto.mealControl.Application.DTOs.TeamManagementDTO;
using noberto.mealControl.Application.Interfaces;

namespace noberto.mealControl.Application.Services;

public class TeamManagementServiceImpl : ITeamManagementService
{
    private readonly IMapper _mapper;
    private readonly IMediator _mediator;

    public TeamManagementServiceImpl(IMapper mapper, IMediator mediator)
    {
        _mapper = mapper;
        _mediator = mediator;
    }

    public async Task CreateTeamManagementAsync(CreateTeamManagementDTO teamManagementDTO)
    {
        var teamManagement = _mapper.Map<CreateTeamManagementCommand>(teamManagementDTO);
        await _mediator.Send(teamManagement);
    }

    public async Task<IEnumerable<TeamManagementSelectDTO>> GetTeamsManagementByStateAsync(string state)
    {
        var teamManagemente = new GetTeamManagementByStateQuery(state);
        return _mapper.Map<IEnumerable<TeamManagementSelectDTO>>(await _mediator.Send(teamManagemente));
    }

    public Task DisableTeamManagementAsync(Guid teamManagementId)
    {
        var teamManagement = new DisableTeamManagementCommand(teamManagementId);
        return _mediator.Send(teamManagement);
    }

    public async Task<IEnumerable<ReturnTeamManagementSectorDTO>> GetTeamManagementByManagerIdAsync(Guid managerId)
    {
        return _mapper.Map<IEnumerable<ReturnTeamManagementSectorDTO>>(
            await _mediator.Send(new GetTeamManagementByManagerIdQuery(managerId)));
    }

    public async Task<ReturnTeamManagementByManagerIdDTO> GetTeamManagementByManagerId(Guid managerId)
    {
        return _mapper.Map<ReturnTeamManagementByManagerIdDTO>(
            await _mediator.Send(new GetTeamManagementByManagerIdQuery(managerId)));
    }
}
