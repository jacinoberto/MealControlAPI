using noberto.mealControl.Core.Entities;

namespace noberto.mealControl.Core.Repositories;

public interface ITeamManagementRepository
{
    Task<TeamManagement> CreateTeamManagementAsync(TeamManagement teamManagement);
    Task<TeamManagement> GetTeamManagementByIdAsync(Guid teamManagementId);
    Task<IEnumerable<TeamManagement>> GetTeamManagementByStateAsync(string state);
    Task<TeamManagement> DisableTeamManagementAsync(Guid teamManagementId);
}
