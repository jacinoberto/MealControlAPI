using noberto.mealControl.Core.Entities;

namespace noberto.mealControl.Core.Repositories;

public interface ITeamManagementRepository
{
    Task<TeamManagement> CreateTeamManagementAsync(TeamManagement teamManagement);
    Task<TeamManagement> GetTeamManagementByIdAsync(Guid teamManagementId);
    Task<IEnumerable<TeamManagement>> GetAllTeamManagementAsync();
    Task<IEnumerable<TeamManagement>> GetTeamManagementByManagerIdAsync(Guid managerId);
    Task<IEnumerable<TeamManagement>> GetTeamManagementByWorkIdAsync(Guid workId);
    Task<IEnumerable<TeamManagement>> GetTeamManagementByStateAsync(string state);
    Task<TeamManagement> DisableTeamManagementAsync(Guid teamManagementId);
}
