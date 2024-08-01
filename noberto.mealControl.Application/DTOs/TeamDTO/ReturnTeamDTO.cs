using noberto.mealControl.Application.DTOs.TeamManagementDTO;
using noberto.mealControl.Application.DTOs.WorkDTO;

namespace noberto.mealControl.Application.DTOs.TeamDTO;

public record ReturnTeamDTO(
    Guid Id,
    Guid AdministratorId,
    ReturnTeamManagementDTO TeamManagement
    );
