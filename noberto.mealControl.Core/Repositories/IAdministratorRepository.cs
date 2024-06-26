using noberto.mealControl.Core.Entities;

namespace noberto.mealControl.Core.Repositories;

public interface IAdministratorRepository
{
    Task<Administrator> CreateAdministratorAsync(Administrator administrator);
    Task<Administrator> GetAdministratorByIdAsync(Guid administratorId);
    Task<Administrator> RecoverAdministratorPasswordAsync(Guid administratorId, string password);
    Task<Administrator> InactivateAdministratorProfileAsync(Guid administratorId);
}
