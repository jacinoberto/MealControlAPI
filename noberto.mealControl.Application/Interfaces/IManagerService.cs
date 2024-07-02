using noberto.mealControl.Application.DTOs.ManagerDTO;

namespace noberto.mealControl.Application.Interfaces;

public interface IManagerService
{
    Task CreateManagerAsync(CreateManagerDTO managerDto);
    Task<IEnumerable<ManagerSelectDTO>> GetManagersByRegistrationOrNameOrEmailAsync(string registrationOrNameOrEmail, string state);
    Task<IEnumerable<ManagerSelectDTO>> GetManagersByStateAsync(string state);
    Task RecoverManagerPassword(Guid managerId, RecoverManagerPasswordDTO recoverPasswordDTO);
    Task InactivateManagerProfile(Guid managerId);
}
