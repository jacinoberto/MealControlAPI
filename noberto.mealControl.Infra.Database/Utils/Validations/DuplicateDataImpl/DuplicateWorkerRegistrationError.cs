using Microsoft.EntityFrameworkCore;
using noberto.mealControl.Core.Entities;
using noberto.mealControl.Core.Enums.Impl;
using noberto.mealControl.Core.Exceptions;
using noberto.mealControl.Infra.Database.Context;

namespace noberto.mealControl.Infra.Database.Utils.Validations.DuplicateDataImpl;

public class DuplicateWorkerRegistrationError : IValidateStrategy<Worker>
{
    private readonly MealControlDbContext _context;

    public DuplicateWorkerRegistrationError(MealControlDbContext context)
    {
        _context = context;
    }

    public async Task Validate(Worker entity)
    {
        var worker = await _context.Workers
        .FirstOrDefaultAsync(worker => worker.Registration == entity.Registration
        && worker.ActiveProfile == true);

        if (worker is null) throw new DuplicateDataException(TypesOfInternalServerErrorEnum
            .DuplicateWorkerRegistration.ToString());
    }
}