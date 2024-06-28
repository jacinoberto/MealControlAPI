using noberto.mealControl.Application.DTOs.UserDTO;

namespace noberto.mealControl.Application.DTOs.AdministratorDTO;

public record struct RecoverAdministratorPasswordDTO(
    RecoverUserPasswordDTO User
    );
