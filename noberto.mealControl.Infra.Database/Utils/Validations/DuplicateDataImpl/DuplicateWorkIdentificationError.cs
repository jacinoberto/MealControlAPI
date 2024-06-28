using Microsoft.EntityFrameworkCore;
using noberto.mealControl.Core.Entities;
using noberto.mealControl.Core.Enums.Impl;
using noberto.mealControl.Core.Exceptions;
using noberto.mealControl.Infra.Database.Context;

namespace noberto.mealControl.Infra.Database.Utils.Validations.DuplicateDataImpl;

public class DuplicateWorkIdentificationError : IValidateStrategy<Work>
{
    private readonly MealControlDbContext _context;

    public DuplicateWorkIdentificationError(MealControlDbContext context)
    {
        _context = context;
    }

    public async Task Validate(Work entity)
    {
        var work = await _context.Works
            .FirstOrDefaultAsync(work => work.Identification == entity.Identification);

        if (work is not null) throw new DuplicateDataException(TypesOfInternalServerErrorEnum
            .DuplicateWorkIdentification.ToString(), entity.Identification);
    }
}
