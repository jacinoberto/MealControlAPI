using noberto.mealControl.Application.DTOs.TeamManagement;

namespace noberto.mealControl.Application.Interfaces;

public interface ITeamManagementService
{
    Task CreateTeamManagementAsync(CreateTeamManagementDTO teamManagementDTO);
    Task<IEnumerable<TeamManagementSelectDTO>> GetTeamsManagementByStateAsync(string state);
    Task DisableTeamManagementAsync(Guid teamManagementId);
}
