using noberto.mealControl.Application.DTOs.UserDTO;

namespace noberto.mealControl.Application.DTOs.ManagerDTO;

public record struct ManagerSelectDTO(
    Guid Id,
    ReturnUsernameDTO User
    );
