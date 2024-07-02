using noberto.mealControl.Application.DTOs.WorkerDTO;
using System.ComponentModel.DataAnnotations;

namespace noberto.mealControl.Application.DTOs.TeamDTO;

public record struct CreateTeamDTO(
    [Required(ErrorMessage = "O ID do Administrador é obrigatório.")]
    Guid AdministratorId,

    [Required(ErrorMessage = "O ID do Encarregado é obrigatório.")]
    Guid ManagerId,

    [Required(ErrorMessage = "O ID do Gerenciamento de Equipe é obrigatório.")]
    Guid TeamManagementId,

    [Required(ErrorMessage = "Os Operários são obrigatórios.")]
    IEnumerable<CreateWorkerDTO> Workers
    );
