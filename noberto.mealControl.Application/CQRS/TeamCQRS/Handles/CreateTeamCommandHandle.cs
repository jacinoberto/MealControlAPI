using AutoMapper;
using MediatR;
using noberto.mealControl.Application.CQRS.TeamCQRS.Commands;
using noberto.mealControl.Core.Entities;
using noberto.mealControl.Core.Repositories;

namespace noberto.mealControl.Application.CQRS.TeamCQRS.Handles;

public class CreateTeamCommandHandle
    : IRequestHandler<CreateTeamCommand, IList<Team>>
{
    private readonly ITeamRepository _repository;
    private readonly IWorkerRepository _workerRepository;
    private readonly IMapper _mapper;

    public CreateTeamCommandHandle(ITeamRepository repository, IWorkerRepository workerRepository, IMapper mapper)
    {
        _repository = repository;
        _workerRepository = workerRepository;
        _mapper = mapper;
    }

    public async Task<IList<Team>> Handle(CreateTeamCommand request, CancellationToken cancellationToken)
    {
        var workers = await _workerRepository.CreateWorkerAsync(_mapper.Map<IEnumerable<Worker>>(request.Workers));
        IList<Team> teams = [];

        foreach (var worker in workers)
        {
            var team = new Team();
            team.AdministratorId = request.AdministratorId;
            team.WorkerId = worker.Id;
            team.TeamManagementId = request.TeamManagementId;

            teams.Add(await _repository.CreateTeamAsync(team));
        }
                
        return teams;
        
    }
}