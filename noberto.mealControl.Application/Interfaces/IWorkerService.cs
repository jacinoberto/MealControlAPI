using noberto.mealControl.Application.DTOs.WorkerDTO;

namespace noberto.mealControl.Application.Interfaces;

public interface IWorkerService
{
    Task<IEnumerable<ReturnWorkerDTO>> GetWorkersByRegistrationOrNameAsync(string registrationOrName);
    Task InactivateWorkerProfile(Guid workerId);
}

