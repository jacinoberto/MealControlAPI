using noberto.mealControl.Core.Entities;

namespace noberto.mealControl.Core.Repositories;

public interface IManagerRepository
{
    Task<Manager> CreateManagerAsync(Manager manager);
    Task<Manager> GetManagerByIdAsync(Guid managerId);
    Task<IEnumerable<Manager>> GetManagersByRegistrationOrNameOrEmailAsync(string registrationOrNameOrEmail);
    Task<IEnumerable<Manager>> GetManagersByStateAsync(string state);
    Task<Manager> RecoverManagerPasswordAsync(string password);
    Task<Manager> InactivateManagerProfileAsync(Guid managerId);
}
