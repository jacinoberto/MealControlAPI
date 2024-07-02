using System.ComponentModel.DataAnnotations;

namespace noberto.mealControl.Application.DTOs.ScheduleEventDTO;

public record struct CreateScheduleEventDTO(
    [Required(ErrorMessage = "O ID do Administrador é obrigatório.")]
    Guid AdministratorId,

    [Required(ErrorMessage = "A Data da Refeição é obrigatória.")]
    DateOnly MealDate,

    [Required(ErrorMessage = "A Descrição é obrigatória.")]
    [MinLength(5, ErrorMessage = "Descrição invalida, a quantidade miníma de caracteres são 5.")]
    [MaxLength(100, ErrorMessage = "Descrição invalida, a quantidade maxíma de caracteres são 100.")]
    string Description,

    IEnumerable<string>? Citys,

    [Required(ErrorMessage = "Definir se o dia é Atípico ou não é obrigatório.")]
    bool Atypical    
    );
