﻿using noberto.mealControl.Application.DTOs.WorkDTO;
using noberto.mealControl.Core.Entities;

namespace noberto.mealControl.Application.Interfaces;

public interface IWorkService
{
    Task CreateWorkAsync(CreateWorkDTO workDto);
    Task<ReturnWorkDTO> GetWorkByIdAsync(Guid workId);
    Task<IEnumerable<ReturnWorkDTO>> GetAllWorkAsync();
    Task<IEnumerable<WorkSelectDTO>> GetWorksByStateAsync(string state);
    Task FinishWorkAsync(Guid workId);
}
