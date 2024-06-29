using System.ComponentModel.DataAnnotations;

namespace noberto.mealControl.Application.DTOs.MealDTO;

public record struct CreateMealDTO(
    [Required(ErrorMessage = "O Café é obrigatório.")]
    bool Coffe,

    [Required(ErrorMessage = "O Almoço é obrigatório.")]
    bool Launch,

    [Required(ErrorMessage = "O Jantar é obrigatório.")]
    bool Dinner,

    [Required(ErrorMessage = "O ID do Administrador é obrigatório.")]
    Guid AdministratorId,

    [Required(ErrorMessage = "O ID da Equipe é obrigatório.")]
    Guid TeamId,

    [Required(ErrorMessage = "O ID da Agenda de Evento Local é obrigatório.")]
    Guid ScheduleLocalEventId
    );
