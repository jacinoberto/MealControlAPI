using Microsoft.EntityFrameworkCore;
using noberto.mealControl.Core.Entities;
using noberto.mealControl.Core.Enums.Impl;
using noberto.mealControl.Core.Exceptions;
using noberto.mealControl.Infra.Database.Context;

namespace noberto.mealControl.Infra.Database.Utils.Validations.DuplicateData;

public class DuplicateAdminRegistrationError : IValidateStrategy<Administrator>
{
    private readonly MealControlDbContext _context;

    public DuplicateAdminRegistrationError(MealControlDbContext context)
    {
        _context = context;
    }

    public async Task Validate(Administrator entity)
    {
        var admin = await _context.Administrators
            .FirstOrDefaultAsync(admin => admin.User.Registration == entity.User.Registration);

        if (admin is null) throw new DuplicateDataException(TypesOfInternalServerErrorEnum
            .DuplicateAdminRegistration.ToString());
    }
}
