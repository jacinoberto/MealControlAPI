using noberto.mealControl.Application.DTOs.TeamDTO;
using noberto.mealControl.Application.DTOs.WorkDTO;

namespace noberto.mealControl.Application.Interfaces;

public interface ITeamService
{
    Task CreateTeamAsync(CreateTeamDTO teamDTO);
    Task<IEnumerable<ReturnTeamWorkDTO>> GetAllTeamsAsync();
    Task<IEnumerable<ReturnTeamWorkerDTO>> GetTeamByManagerIdAsync(Guid managerId);
    Task DisableTeamAsync(Guid teamId);
}
