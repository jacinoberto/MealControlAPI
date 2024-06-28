using Microsoft.EntityFrameworkCore;
using noberto.mealControl.Core.Entities;
using noberto.mealControl.Core.Enums.Impl;
using noberto.mealControl.Core.Exceptions;
using noberto.mealControl.Infra.Database.Context;

namespace noberto.mealControl.Infra.Database.Utils.Validations.DuplicateDataImpl;

public class DuplicateTeamManagementWorkError : IValidateStrategy<TeamManagement>
{
    private readonly MealControlDbContext _context;

    public DuplicateTeamManagementWorkError(MealControlDbContext context)
    {
        _context = context;
    }

    public async Task Validate(TeamManagement entity)
    {
        var teamManagement = await _context.TeamManagement
            .FirstOrDefaultAsync(teamManagement => teamManagement.ManagerId == entity.ManagerId
            && teamManagement.WorkId == entity.WorkId);

        if (teamManagement is not null) throw new DuplicateDataException(TypesOfInternalServerErrorEnum
            .DuplicateTeamManagementWork.ToString());
    }
}
