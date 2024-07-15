namespace noberto.mealControl.Application.DTOs.WorkDTO;

public record ReturnWorkDTO(
    Guid Id,
    string Identification,
    DateOnly StartDate,
    DateOnly ClosingDate
    );
