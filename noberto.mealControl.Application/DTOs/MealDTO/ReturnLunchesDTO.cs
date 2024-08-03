using noberto.mealControl.Application.DTOs.TeamDTO;
using noberto.mealControl.Application.DTOs.WorkerDTO;

namespace noberto.mealControl.Application.DTOs.MealDTO;

public record ReturnLunchesDTO(
    Guid Id,
    bool Lunch,
    ReturnTeamWorkerDTO Team
    );
