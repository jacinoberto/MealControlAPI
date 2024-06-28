using Microsoft.EntityFrameworkCore;
using noberto.mealControl.Core.Entities;
using noberto.mealControl.Core.Enums.Impl;
using noberto.mealControl.Core.Exceptions;
using noberto.mealControl.Core.Repositories;
using noberto.mealControl.Infra.Database.Context;

namespace noberto.mealControl.Infra.Database.Repositories;

public class TeamRepositoryImpl : ITeamRepository
{
    private readonly MealControlDbContext _context;

    public TeamRepositoryImpl(MealControlDbContext context)
    {
        _context = context;
    }

    public async Task<Team> CreateTeamAsync(Team team)
    {
        await _context.AddAsync(team);
        await _context.SaveChangesAsync();
        return team;
    }

    public async Task<Team> GetTeamByIdAsync(Guid teamId)
    {
        var team = await _context.Teams.FindAsync(teamId);

        return team is null ? throw new EntityNotFoundException(TypesNotFoundEnum
            .TeamNotFoundById.ToString())
                : team.ActiveTeam is true ? team
                    : throw new ServerErrorException(TypesOfInternalServerErrorEnum
                        .InactiveTeam.ToString());
    }

    public async Task<IEnumerable<Team>> GetTeamsByIdManagerAsync(Guid managerId)
    {
        var teams = await _context.Teams
            .Where(team => team.TeamManagement.ManagerId == managerId
            && team.ActiveTeam == true)
            .ToListAsync();

        return teams.Count is not 0 ? teams
            : throw new EntityNotFoundException(TypesNotFoundEnum.
                TeamNotFoundByManagerId.ToString());
    }

    public async Task<Team> DisableTeamAsync(Guid teamId)
    {
        var team = await GetTeamByIdAsync(teamId);

        team.InactivateTeam();
        await _context.SaveChangesAsync();
        return team;
    }
}
