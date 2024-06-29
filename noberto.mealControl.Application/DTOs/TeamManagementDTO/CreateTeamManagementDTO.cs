using System.ComponentModel.DataAnnotations;

namespace noberto.mealControl.Application.DTOs.TeamManagement;

public record struct CreateTeamManagementDTO(
    [Required(ErrorMessage = "O Setor é obrigatório.")]
    [MinLength(3, ErrorMessage = "Setor invalido, o minímo de caracteres permitidos são 3.")]
    [MaxLength(30, ErrorMessage = "Setor invalido, o maxímo de caracteres permitidos são 30.")]
    string Sector,

    [Required(ErrorMessage = "O ID Administrador é obrigatório.")]
    Guid AdministratorId,

    [Required(ErrorMessage = "O ID do Encarregado é obrigatório.")]
    Guid ManagerId,

    [Required(ErrorMessage = "O ID da Obra é obrigatório.")]
    Guid WorkId
    );
