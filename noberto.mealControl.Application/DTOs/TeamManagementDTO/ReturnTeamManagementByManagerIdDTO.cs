using noberto.mealControl.Application.DTOs.ManagerDTO;
using noberto.mealControl.Application.DTOs.UserDTO;

namespace noberto.mealControl.Application.DTOs.TeamManagementDTO;

public record ReturnTeamManagementByManagerIdDTO(
    Guid Id,
    ReturnManagerUsernameDTO Manager,
    string Sector
    );