using Microsoft.EntityFrameworkCore;
using noberto.mealControl.Core.Entities;
using noberto.mealControl.Core.Enums.Impl;
using noberto.mealControl.Core.Exceptions;
using noberto.mealControl.Core.Repositories;
using noberto.mealControl.Infra.Database.Context;
using noberto.mealControl.Infra.Database.Utils.Validations;

namespace noberto.mealControl.Infra.Database.Repositories;

public class WorkerRepositoryImpl : IWorkerRepository
{
     readonly MealControlDbContext _context;
    private readonly IEnumerable<IValidateStrategy<Worker>> _validations;

    public WorkerRepositoryImpl(MealControlDbContext context,
        IEnumerable<IValidateStrategy<Worker>> validations)
    {
        _context = context;
        _validations = validations;
    }

    public async Task<IEnumerable<Worker>> CreateWorkersAsync(IEnumerable<Worker> workers)
    {
        foreach (var worker in workers)
        {
            foreach (var entity in _validations)
            {
                await entity.Validate(worker);
            }
            
            await _context.AddAsync(worker);
            await _context.SaveChangesAsync();
        }

        return workers;
    }

    public async Task<Worker> GetWorkerByIdAsync(Guid workerId)
    {
        var worker = await _context.Workers.FindAsync(workerId);
        
        return worker is null ? throw new EntityNotFoundException(
            TypesNotFoundEnum.WorkerNotFoundById.ToString())
                : worker.ActiveProfile is true ? worker
                    : throw new ServerErrorException(TypesOfInternalServerErrorEnum
                    .InactiveWorker.ToString());
    }

    public async Task<IEnumerable<Worker>> GetWorkersByRegistrationOrNameAsync(string registrationOrName)
    {
        var workers = await _context.Workers
            .Where(worker => worker.Registration.ToUpper().Contains(registrationOrName.ToUpper())
            || worker.Name.ToUpper().Contains(registrationOrName.ToUpper())
            && worker.ActiveProfile == true)
            .ToListAsync();
        
        return workers.Count is not 0 ? workers
            : throw new EntityNotFoundException(TypesNotFoundEnum.ManagerNotFound.ToString());
    }

    public Task<Worker> InactivateWorkerProfileAsync(Worker worker)
    {
        throw new NotImplementedException();
    }
}