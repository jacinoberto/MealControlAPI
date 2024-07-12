using System.ComponentModel.DataAnnotations;

namespace noberto.mealControl.Application.DTOs.ScheduleLocalEventDTO;

public record struct CreateScheduleLocalEventDTO(
    Guid? AdministratorId,
    Guid ScheduleEventId,
    Guid WorkId
    );
