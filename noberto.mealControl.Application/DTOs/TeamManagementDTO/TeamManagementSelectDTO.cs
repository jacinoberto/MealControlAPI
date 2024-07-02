using noberto.mealControl.Application.DTOs.ManagerDTO;

namespace noberto.mealControl.Application.DTOs.TeamManagement;

public record struct TeamManagementSelectDTO(
    Guid Id,
    ManagerSelectDTO Manager,
    string Sector
    );
