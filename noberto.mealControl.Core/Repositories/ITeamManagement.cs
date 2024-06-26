using noberto.mealControl.Core.Entities;

namespace noberto.mealControl.Core.Repositories;

public interface ITeamManagement
{
    Task<TeamManagement> CreateTeamManagementAsync(TeamManagement teamManagement);
    Task<TeamManagement> GetTeamManagementByIdAsync(Guid teamManagementId);
    Task<IEnumerable<TeamManagement>> GetTeamManagementByStateAsync(string state);
    Task<TeamManagement> DisableTeamManagementAsync(TeamManagement teamManagement);
}
