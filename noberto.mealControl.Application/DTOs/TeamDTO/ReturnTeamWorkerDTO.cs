using noberto.mealControl.Application.DTOs.WorkerDTO;

namespace noberto.mealControl.Application.DTOs.TeamDTO;

public record struct ReturnTeamWorkerDTO(
    ReturnWorkerNameDTO Worker
    );
