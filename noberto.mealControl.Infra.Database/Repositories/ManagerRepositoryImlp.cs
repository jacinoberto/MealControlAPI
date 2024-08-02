using Microsoft.EntityFrameworkCore;
using noberto.mealControl.Core.Entities;
using noberto.mealControl.Core.Enums.Impl;
using noberto.mealControl.Core.Exceptions;
using noberto.mealControl.Core.Repositories;
using noberto.mealControl.Infra.Database.Context;
using noberto.mealControl.Infra.Database.Utils.Validations;

namespace noberto.mealControl.Infra.Database.Repositories;

public class ManagerRepositoryImlp : IManagerRepository
{
    private readonly MealControlDbContext _context;
    private readonly IEnumerable<IValidateStrategy<Manager>> _validations;

    public ManagerRepositoryImlp(MealControlDbContext context,
        IEnumerable<IValidateStrategy<Manager>> validations)
    {
        _context = context;
        _validations = validations;
    }

    public async Task<Manager> CreateManagerAsync(Manager manager)
    {
        foreach (var entity in _validations)
        {
            await entity.Validate(manager);
        }

        await _context.Managers.AddAsync(manager);
        await _context.SaveChangesAsync();
        return manager;
    }

    public async Task<Manager> GetManagerByEmailAndPassword(string email, string password)
    {
        return await _context.Managers
            .FirstOrDefaultAsync(manager => manager.User.Email == email
            && manager.User.Password == password) ?? throw new EntityNotFoundException(
                TypesNotFoundEnum.ManagerNotFoundByEmailAndPassword.ToString());
    }

    public async Task<Manager> GetManagerByIdAsync(Guid managerId)
    {
        return await _context.Managers
            .FirstOrDefaultAsync(manager => manager.Id == managerId
            && manager.User.ActiveProfile == true) ??
            throw new EntityNotFoundException(TypesNotFoundEnum
            .ManagerNotFound.ToString());
    }

    public async Task<IEnumerable<Manager>> GetManagersByRegistrationOrNameOrEmailAsync(string registrationOrNameOrEmail, string state)
    {
        var managers = await _context.Managers
            .Where(manager => manager.User.Registration.Contains(registrationOrNameOrEmail)
            || manager.User.Name.ToUpper().Contains(registrationOrNameOrEmail.ToUpper())
            || manager.User.Email.ToUpper().Contains(registrationOrNameOrEmail.ToUpper())
            && manager.Address.State == state && manager.User.ActiveProfile == true)
            .ToListAsync();

        return managers.Count is not 0 ? managers
            : throw new EntityNotFoundException(TypesNotFoundEnum
                .ManagerNotFoundForTheRegion.ToString());
    }

    public async Task<IEnumerable<Manager>> GetManagersByStateAsync(string state)
    {
        var managers = await _context.Managers
            .Where(manager => manager.Address.State.ToUpper() == state.ToUpper()
            && manager.User.ActiveProfile == true)
            .ToListAsync();

        return managers.Count is not 0 ? managers
            : throw new EntityNotFoundException(TypesNotFoundEnum
                .ManagerNotFoundForTheRegion.ToString());
    }

    public async Task<Manager> InactivateManagerProfileAsync(Guid managerId)
    {
        var manager = await GetManagerByIdAsync(managerId);
                
        manager.User.DeactivateProfile();
        await _context.SaveChangesAsync();
        return manager;        
    }

    public async Task<Manager> RecoverManagerPasswordAsync(Guid managerId, string password)
    {
        var manager = await GetManagerByIdAsync(managerId);

        manager.User.ChangePassword(password);
        await _context.SaveChangesAsync();

        return manager;
    }
}
