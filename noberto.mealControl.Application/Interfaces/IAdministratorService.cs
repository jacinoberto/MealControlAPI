using noberto.mealControl.Application.DTOs.AdministratorDTO;

namespace noberto.mealControl.Application.Interfaces;

public interface IAdministratorService
{
    Task CreateAdministratorAsync(CreateAdministratorDTO administratorDto);
    Task RecoverAdministratorPassword(Guid administratorId, string password);
    Task InactivateAdministratorProfile(Guid administratorId);
}
