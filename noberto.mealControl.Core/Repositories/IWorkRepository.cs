using noberto.mealControl.Core.Entities;

namespace noberto.mealControl.Core.Repositories;

public interface IWorkRepository
{
    Task<Work> CreateWorkAsync(Work work);
    Task<Work> GetWorkByIdAsync(Guid workId);
    Task<IEnumerable<Work>> GetWorksByCityAsync(IEnumerable<string> city);
    Task<IEnumerable<Work>> GetWorksByStateAsync(string state);
    Task<ICollection<Work>> GetAllWorksAsync();
    Task<Work> FinishWorkAsync(Guid workId);
}
