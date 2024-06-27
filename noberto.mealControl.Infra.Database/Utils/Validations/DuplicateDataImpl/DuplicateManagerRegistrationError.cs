using Microsoft.EntityFrameworkCore;
using noberto.mealControl.Core.Entities;
using noberto.mealControl.Core.Enums.Impl;
using noberto.mealControl.Core.Exceptions;
using noberto.mealControl.Infra.Database.Context;

namespace noberto.mealControl.Infra.Database.Utils.Validations.DuplicateDataImpl;

public class DuplicateManagerRegistrationError : IValidateStrategy<Manager>
{
    private readonly MealControlDbContext _context;

    public DuplicateManagerRegistrationError(MealControlDbContext context)
    {
        _context = context;
    }

    public async Task Validate(Manager entity)
    {
        var manager = await _context.Managers
            .FirstOrDefaultAsync(manager => manager.User.Registration == entity.User.Registration);

        if (manager is null) throw new DuplicateDataException(TypesOfInternalServerErrorEnum
            .DuplicateManagerRegistration.ToString());
    }
}
