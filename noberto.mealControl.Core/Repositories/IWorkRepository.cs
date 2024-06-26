using noberto.mealControl.Core.Entities;

namespace noberto.mealControl.Core.Repositories;

public interface IWorkRepository
{
    Task<Work> CreateWorkAsync(Work work);
    Task<Work> GetWorkByIdAsync(Guid workId);
    Task<IEnumerable<Work>> GetWorksByStateAsync(string state);
    Task<Work> FinishWorkAsync(Work work);
}
