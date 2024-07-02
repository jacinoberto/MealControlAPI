using noberto.mealControl.Application.DTOs.AdministratorDTO;
using noberto.mealControl.Core.Entities;

namespace noberto.mealControl.Application.Interfaces;

public interface IAdministratorService
{
    Task<Administrator> CreateAdministratorAsync(CreateAdministratorDTO administratorDto);
    Task RecoverAdministratorPasswordAsync(Guid administratorId, RecoverAdministratorPasswordDTO password);
    Task InactivateAdministratorProfileAsync(Guid administratorId);
}
