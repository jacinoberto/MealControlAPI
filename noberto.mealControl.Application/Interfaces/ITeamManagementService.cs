using noberto.mealControl.Application.DTOs.TeamManagement;
using noberto.mealControl.Application.DTOs.TeamManagementDTO;

namespace noberto.mealControl.Application.Interfaces;

public interface ITeamManagementService
{
    Task CreateTeamManagementAsync(CreateTeamManagementDTO teamManagementDTO);
    Task<IEnumerable<ReturnTeamManagementByManagerIdDTO>> GetTeamManagementByManagerId(Guid managerId);
    Task<IEnumerable<ReturnTeamManagementSectorDTO>> GetTeamManagementByManagerIdAsync(Guid managerId);
    Task<IEnumerable<TeamManagementSelectDTO>> GetTeamsManagementByStateAsync(string state);
    Task DisableTeamManagementAsync(Guid teamManagementId);
}
