using noberto.mealControl.Application.DTOs.TeamDTO;
using noberto.mealControl.Application.DTOs.WorkerDTO;

namespace noberto.mealControl.Application.DTOs.MealDTO;

public record ReturnCoffesDTO(
    Guid Id,
    bool Coffee,
    ReturnTeamWorkerDTO Team
    );
