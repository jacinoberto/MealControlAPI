namespace noberto.mealControl.Application.DTOs.WorkerDTO;

public record struct ReturnWorkerDTO(
    Guid Id,
    string Registration,
    string Name
    );