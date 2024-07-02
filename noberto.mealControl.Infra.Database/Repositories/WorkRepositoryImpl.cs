using Microsoft.EntityFrameworkCore;
using noberto.mealControl.Core.Entities;
using noberto.mealControl.Core.Enums.Impl;
using noberto.mealControl.Core.Exceptions;
using noberto.mealControl.Core.Repositories;
using noberto.mealControl.Infra.Database.Context;
using noberto.mealControl.Infra.Database.Utils.Validations;

namespace noberto.mealControl.Infra.Database.Repositories;

public class WorkRepositoryImpl : IWorkRepository
{
    private readonly MealControlDbContext _context;
    private readonly IEnumerable<IValidateStrategy<Work>> _validations;

    public WorkRepositoryImpl(MealControlDbContext context,
        IEnumerable<IValidateStrategy<Work>> validations)
    {
        _context = context;
        _validations = validations;
    }

    public async Task<Work> CreateWorkAsync(Work work)
    {
        foreach (var entity in _validations)
        {
            await entity.Validate(work);
        }

        await _context.AddAsync(work);
        await _context.SaveChangesAsync();
        return work;
    }

    public async Task<Work> GetWorkByIdAsync(Guid workId)
    {
        return await _context.Works
            .FirstOrDefaultAsync(work => work.Id == workId
            && work.ClosingDate == null) ??
            throw new EntityNotFoundException(TypesNotFoundEnum.WorkNotFoundById.ToString());
    }

    public async Task<IEnumerable<Work>> GetWorksByStateAsync(string state)
    {
        var works = await _context.Works
            .Where(work => work.Address.State.ToUpper() == state.ToUpper()
            && work.ClosingDate == null)
            .Include(work => work.Address)
            .ToListAsync();

        return works.Count is not 0 ? works
            : throw new EntityNotFoundException(TypesNotFoundEnum.WorkNotFoundForTheRegion.ToString());
    }

    public async Task<Work> FinishWorkAsync(Guid workId)
    {
        var work = await GetWorkByIdAsync(workId);

        work.FinishWork();
        await _context.SaveChangesAsync();
        return work;
    }

    public async Task<IEnumerable<Work>> GetWorksByCityAsync(IEnumerable<string> cities)
    {
        IList<Work> works = new List<Work>();

        foreach (var city in cities)
        {
            var cityUpper = city.ToUpper();
            var results = await _context.Works
                .Where(work => work.Address.City.ToUpper().Contains(cityUpper)
                && work.ClosingDate == null)
                .ToListAsync();

            foreach (var result in results)
            {
                works.Add(result);
            }
        }

        return works.Count != 0 ? works : await _context.Works.ToArrayAsync();
    }
}
