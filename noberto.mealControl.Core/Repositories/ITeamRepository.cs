using noberto.mealControl.Core.Entities;

namespace noberto.mealControl.Core.Repositories;

public interface ITeamRepository
{
    Task<Team> CreateTeamAsync(Team team);
    Task<Team> GetTeamByIdAsync(Guid teamId);
    Task<IEnumerable<Team>> GetTeamsByIdManagerAsync(Guid managerId);
    Task<Team> DisableTeamAsync(Guid teamId);
}
