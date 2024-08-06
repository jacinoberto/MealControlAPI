using noberto.mealControl.Core.Entities;

namespace noberto.mealControl.Core.Repositories;

public interface IManagerRepository
{
    Task<Manager> CreateManagerAsync(Manager manager);
    Task<Manager> GetManagerByIdAsync(Guid managerId);
    Task<IEnumerable<Manager>> GetAllManagersAsync();
    Task<Manager> GetManagerByEmailAndPassword(string email, string password);
    Task<IEnumerable<Manager>> GetManagersByRegistrationOrNameOrEmailAsync(string registrationOrNameOrEmail, string state);
    Task<IEnumerable<Manager>> GetManagersByStateAsync(string state);
    Task<Manager> RecoverManagerPasswordAsync(Guid managerId, string password);
    Task<Manager> InactivateManagerProfileAsync(Guid managerId);
}
