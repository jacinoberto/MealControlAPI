using noberto.mealControl.Core.Entities;

namespace noberto.mealControl.Core.Repositories;

public interface IWorkerRepository
{
    Task<Worker> CreateWorkerAsync(Worker worker);
    Task<Worker> GetWorkerByIdAsync(Guid workerId);
    Task<IEnumerable<Worker>> GetWorkersByRegistrationOrNameAsync(string registrationOrName);
    Task<Worker> InactivateWorkerProfileAsync(Guid workerId);
}
