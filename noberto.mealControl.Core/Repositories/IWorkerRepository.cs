using noberto.mealControl.Core.Entities;

namespace noberto.mealControl.Core.Repositories;

public interface IWorkerRepository
{
    Task<IEnumerable<Worker>> CreateWorkersAsync(IEnumerable<Worker> workers);
    Task<Worker> GetWorkerByIdAsync(Guid workerId);
    Task<IEnumerable<Worker>> GetWorkersByRegistrationOrNameAsync(string registrationOrName);
    Task<Worker> InactivateWorkerProfileAsync(Worker worker);
}
