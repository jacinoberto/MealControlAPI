using noberto.mealControl.Application.DTOs.TeamDTO;
using noberto.mealControl.Application.DTOs.WorkerDTO;

namespace noberto.mealControl.Application.DTOs.MealDTO;

public record ReturnDinnersDTO(
    Guid Id,
    bool Dinner,
    ReturnTeamWorkerDTO Team
    );
