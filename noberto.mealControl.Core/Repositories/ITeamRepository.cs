using noberto.mealControl.Core.Entities;

namespace noberto.mealControl.Core.Repositories;

public interface ITeamRepository
{
    Task<Team> CreateTeamAsync(Team team);
    Task<Team> GetTeamByIdAsync(Guid teamId);
    Task<IEnumerable<Team>> GetAllTeams();
    Task<IEnumerable<Team>> GetTeamsByWorkerIdAsync(Guid workerId);
    Task<IEnumerable<Team>> GetTeamsByIdManagerAsync(Guid managerId);
    Task<IEnumerable<Team>> GetTeamsByManagerIdAsync(Guid managerId);
    Task<IEnumerable<Team>> GetTeamsByWorkIdAsync(Guid workId);
    Task<IEnumerable<Team>> GetTeamsByTeamManagementIdAsync(Guid teamManagementId);
    Task<Team> DisableTeamAsync(Guid teamId);
}
