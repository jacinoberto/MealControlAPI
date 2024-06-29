using System.ComponentModel.DataAnnotations;

namespace noberto.mealControl.Application.DTOs.ScheduleLocalEventDTO;

public record struct CreateScheduleLocalEventDTO(
    [Required(ErrorMessage = "O ID do Administrador é obrigatório.")]
    Guid AdministratorId,

    [Required(ErrorMessage = "O ID da Agenda de Evento é obrigatório.")]
    Guid ScheduleEventId,

    [Required(ErrorMessage = "O ID da Obra é obrigatório.")]
    Guid WorkId
    );
