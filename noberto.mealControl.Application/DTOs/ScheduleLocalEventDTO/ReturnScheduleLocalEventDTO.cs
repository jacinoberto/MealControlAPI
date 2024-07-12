namespace noberto.mealControl.Application.DTOs.ScheduleLocalEventDTO;

public record struct ReturnScheduleLocalEventDTO(
    Guid Id,
    Guid AdministratorId,
    Guid ScheduleEventId,
    Guid WorkId
    );
