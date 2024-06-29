using Microsoft.EntityFrameworkCore;
using noberto.mealControl.Core.Entities;
using noberto.mealControl.Core.Enums.Impl;
using noberto.mealControl.Core.Exceptions;
using noberto.mealControl.Core.Repositories;
using noberto.mealControl.Infra.Database.Context;
using noberto.mealControl.Infra.Database.Utils.Validations;

namespace noberto.mealControl.Infra.Database.Repositories;

public class TeamManagementRepositoryImpl : ITeamManagementRepository
{
    private readonly MealControlDbContext _context;
    private readonly IEnumerable<IValidateStrategy<TeamManagement>> _validations;

    public TeamManagementRepositoryImpl(MealControlDbContext context,
        IEnumerable<IValidateStrategy<TeamManagement>> validations)
    {
        _context = context;
        _validations = validations;
    }

    public async Task<TeamManagement> CreateTeamManagementAsync(TeamManagement teamManagement)
    {
        foreach (var entity in _validations)
        {
            await entity.Validate(teamManagement);
        }

        await _context.AddAsync(teamManagement);
        await _context.SaveChangesAsync();
        return teamManagement;
    }

    public async Task<TeamManagement> GetTeamManagementByIdAsync(Guid teamManagementId)
    {
        var teamManagement = await _context.TeamManagement.FindAsync(teamManagementId);

        return teamManagement is null ? throw new EntityNotFoundException(TypesNotFoundEnum
            .TeamManagementNotFoundById.ToString())
                : teamManagement.ActiveTeam is true ? teamManagement
                    : throw new ServerErrorException(TypesOfInternalServerErrorEnum
                        .InactiveTeamManagement.ToString());
    }
    public async Task<IEnumerable<TeamManagement>> GetTeamManagementByManagerIdAsync(Guid managerId)
    {
        return await _context.TeamManagement
            .Where(teamManagement => teamManagement.ManagerId == managerId
            && teamManagement.ActiveTeam == true)
            .ToListAsync();
    }

    public async Task<IEnumerable<TeamManagement>> GetTeamManagementByWorkIdAsync(Guid workId)
    {
        return await _context.TeamManagement
            .Where(teamManagement => teamManagement.WorkId == workId
            && teamManagement.ActiveTeam == true)
            .ToListAsync();
    }

    public async Task<IEnumerable<TeamManagement>> GetTeamManagementByStateAsync(string state)
    {
        var teamManagement = await _context.TeamManagement
            .Where(teamManagement => teamManagement.Manager.Address.State == state
            && teamManagement.ActiveTeam == true)
            .ToListAsync();

        return teamManagement.Count is not 0 ? teamManagement
            : throw new EntityNotFoundException(TypesNotFoundEnum
                .TeamManagementNotFoundForTheRegion.ToString());
    }

    public async Task<TeamManagement> DisableTeamManagementAsync(Guid teamManagementId)
    {
        var teamManagement = await GetTeamManagementByIdAsync(teamManagementId);

        teamManagement.InactvateTeam();
        await _context.SaveChangesAsync();
        return teamManagement;
    }

    
}
