using noberto.mealControl.Application.DTOs.WorkDTO;
using noberto.mealControl.Core.Entities;

namespace noberto.mealControl.Application.BackgroundService.Utils.Filters.FilterWorks;

public interface IFilterWorks
{
    Task<ISet<WorkIdDTO>> Filter(DateOnly date, ICollection<Work> works,
        ISet<WorkIdDTO> pendingWorks);
}
