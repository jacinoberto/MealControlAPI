using noberto.mealControl.Application.DTOs.ManagerDTO;

namespace noberto.mealControl.Application.DTOs.TeamManagement;

public record struct TeamManagementSelectDTO(
    ManagerSelectDTO Manager,
    string Sector
    );
