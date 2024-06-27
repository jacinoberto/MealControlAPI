using noberto.mealControl.Core.Entities;
using noberto.mealControl.Core.Enums.Impl;
using noberto.mealControl.Core.Exceptions;
using noberto.mealControl.Core.Repositories;
using noberto.mealControl.Infra.Database.Context;
using noberto.mealControl.Infra.Database.Utils.Validations;

namespace noberto.mealControl.Infra.Database.Repositories;

public class AdministratorRepositoryImpl : IAdministratorRepository
{
    private readonly MealControlDbContext _context;
    private readonly IEnumerable<IValidateStrategy<Administrator>> _validations;

    public AdministratorRepositoryImpl(MealControlDbContext context,
        IEnumerable<IValidateStrategy<Administrator>> validations)
    {
        _context = context;
        _validations = validations;
    }

    public async Task<Administrator> CreateAdministratorAsync(Administrator administrator)
    {
        foreach (var entity in _validations)
        {
            await entity.Validate(administrator);
        }

        await _context.AddAsync(administrator);
        await _context.SaveChangesAsync();
        return administrator;
    }

    public async Task<Administrator> GetAdministratorByIdAsync(Guid administratorId)
    { 
        return await _context.Administrators.FindAsync(administratorId) ?? 
            throw new EntityNotFoundException(TypesNotFoundEnum
            .AdminNotFound.ToString());
    }

    public async Task<Administrator> InactivateAdministratorProfileAsync(Guid administratorId)
    {
        var administrator = await GetAdministratorByIdAsync(administratorId);

        administrator.User.DeactivateProfile();
        await _context.SaveChangesAsync();
        
        return administrator;
    }

    public async Task<Administrator> RecoverAdministratorPasswordAsync(Guid administratorId, string password)
    {
        var administrator = await GetAdministratorByIdAsync(administratorId);

        administrator.User.ChangePassword(password);
        await _context.SaveChangesAsync();

        return administrator;
    }
}
