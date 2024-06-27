using Microsoft.EntityFrameworkCore;
using noberto.mealControl.Core.Entities;
using noberto.mealControl.Core.Enums.Impl;
using noberto.mealControl.Core.Exceptions;
using noberto.mealControl.Infra.Database.Context;

namespace noberto.mealControl.Infra.Database.Utils.Validations.DuplicateData;

public class DuplicateAdminEmailError : IValidateStrategy<Administrator>
{
    private readonly MealControlDbContext _context;

    public DuplicateAdminEmailError(MealControlDbContext context)
    {
        _context = context;
    }

    public async Task Validate(Administrator entity)
    {
        var admin = await _context.Administrators
             .FirstOrDefaultAsync(admin => admin.User.Email == entity.User.Email);

        if (admin is null) throw new DuplicateDataException(TypesOfInternalServerErrorEnum
            .DuplicateAdminEmail.ToString());
    }
}
