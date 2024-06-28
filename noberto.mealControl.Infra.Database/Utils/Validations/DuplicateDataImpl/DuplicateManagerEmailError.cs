using Microsoft.EntityFrameworkCore;
using noberto.mealControl.Core.Entities;
using noberto.mealControl.Core.Enums.Impl;
using noberto.mealControl.Core.Exceptions;
using noberto.mealControl.Infra.Database.Context;

namespace noberto.mealControl.Infra.Database.Utils.Validations.DuplicateDataImpl;

public class DuplicateManagerEmailError : IValidateStrategy<Manager>
{
    private readonly MealControlDbContext _context;

    public DuplicateManagerEmailError(MealControlDbContext context)
    {
        _context = context;
    }

    public async Task Validate(Manager entity)
    {
        var manager = await _context.Managers
            .FirstOrDefaultAsync(manager => manager.User.Email == entity.User.Email);

        if (manager is not null) throw new DuplicateDataException(TypesOfInternalServerErrorEnum
            .DuplicateManagerEmail.ToString(), entity.User.Email);
    }
}
