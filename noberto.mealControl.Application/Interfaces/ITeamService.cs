using noberto.mealControl.Application.DTOs.TeamDTO;
using noberto.mealControl.Application.DTOs.WorkDTO;

namespace noberto.mealControl.Application.Interfaces;

public interface ITeamService
{
    Task CreateTeamAsync(CreateTeamDTO teamDTO);
    Task<ReturnTeamDTO> GetTeamByIdAsync(Guid teamId);
    Task<IEnumerable<ReturnTeamDTO>> GetAllTeamsAsync();
    Task<IEnumerable<ReturnTeamWorkerDTO>> GetTeamByManagerIdAsync(Guid managerId);
    Task DisableTeamAsync(Guid teamId);
}
