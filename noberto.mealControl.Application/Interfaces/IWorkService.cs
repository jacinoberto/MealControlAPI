using noberto.mealControl.Application.DTOs.WorkDTO;
using noberto.mealControl.Core.Entities;

namespace noberto.mealControl.Application.Interfaces;

public interface IWorkService
{
    Task CreateWorkAsync(CreateWorkDTO workDto);
    Task<IEnumerable<WorkSelectDTO>> GetWorksByStateAsync(string state);
    Task FinishWorkAsync(Guid workId);
}
