using noberto.mealControl.Application.DTOs.WorkDTO;

namespace noberto.mealControl.Application.DTOs.TeamDTO;

public record struct ReturnTeamWorkDTO(
    Guid Id,
    ReturnWorkDTO Work
    );
