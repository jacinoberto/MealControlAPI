namespace noberto.mealControl.Application.DTOs.ScheduleEventDTO;

public record ReturnScheduleEventDTO(
    Guid Id,
    Guid AdministratorId,
    DateOnly MealDate,
    string? Description,
    bool Atypical
    );
