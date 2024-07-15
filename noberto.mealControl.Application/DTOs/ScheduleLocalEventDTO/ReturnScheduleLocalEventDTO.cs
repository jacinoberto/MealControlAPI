using noberto.mealControl.Application.DTOs.ScheduleEventDTO;
using noberto.mealControl.Application.DTOs.WorkDTO;

namespace noberto.mealControl.Application.DTOs.ScheduleLocalEventDTO;

public record ReturnScheduleLocalEventDTO(
    Guid Id,
    Guid AdministratorId,
    Guid ScheduleEventId,
    Guid WorkId,
    ReturnWorkDTO Work,
    ReturnScheduleEventDTO ScheduleEvent
    );
