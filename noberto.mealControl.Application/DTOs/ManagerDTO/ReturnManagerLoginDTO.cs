using noberto.mealControl.Application.DTOs.UserDTO;

namespace noberto.mealControl.Application.DTOs.ManagerDTO;

public record ReturnManagerLoginDTO(
    Guid Id,
    ReturnUsernameDTO User
    );
