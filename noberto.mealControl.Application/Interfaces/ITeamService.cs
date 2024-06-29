using noberto.mealControl.Application.DTOs.TeamDTO;

namespace noberto.mealControl.Application.Interfaces;

public interface ITeamService
{
    Task CreateTeamAsync(CreateTeamDTO teamDTO);
    Task<IEnumerable<ReturnTeamWorkerDTO>> GetTeamByManagerIdAsync(Guid managerId);
    Task DisableTeamAsync(Guid teamId);
}
