using AutoMapper;
using MediatR;
using noberto.mealControl.Application.CQRS.TeamCQRS.Commands;
using noberto.mealControl.Application.CQRS.TeamCQRS.Queries;
using noberto.mealControl.Application.DTOs.TeamDTO;
using noberto.mealControl.Application.Interfaces;

namespace noberto.mealControl.Application.Services;

public class TeamServiceImpl : ITeamService
{
    private readonly IMapper _mapper;
    private readonly IMediator _mediator;

    public TeamServiceImpl(IMapper mapper, IMediator mediator)
    {
        _mapper = mapper;
        _mediator = mediator;
    }

    public async Task CreateTeamAsync(CreateTeamDTO teamDTO)
    {
        var team = _mapper.Map<CreateTeamCommand>(teamDTO);
        await _mediator.Send(team);
    }

    public async Task<IEnumerable<ReturnTeamWorkerDTO>> GetTeamByManagerIdAsync(Guid managerId)
    {
        var team = new GetTeamByManagerIdQuery(managerId);
        return _mapper.Map<IEnumerable<ReturnTeamWorkerDTO>>(await _mediator.Send(team));
    }

    public async Task DisableTeamAsync(Guid teamId)
    {
        var team = new DisableTeamCommand(teamId);
        await _mediator.Send(team);
    }
}
