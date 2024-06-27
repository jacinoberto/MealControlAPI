using noberto.mealControl.Core.Enums.Impl;
using noberto.mealControl.Core.Exceptions;

namespace noberto.mealControl.Core.Entities;

public class TeamManagement : Identifier
{
    public string Sector { get; private set; }
    public bool ActiveTeam { get; private set; }

    public Guid AdministratorId { get; set; }
    public Guid ManagerId { get; set; }
    public Guid WorkId { get; set; }
    public Administrator Administrator { get; set; }
    public Manager Manager { get; set; }
    public Work Work { get; set; }
    public IEnumerable<Team> Teams { get; set; }

    public TeamManagement(string sector)
    {
        ValidateManageTeamData(sector);
    }

    /// <summary>
    /// Validar dados informados para a criação de um novo Gerenciamento de Equipe
    /// </summary>
    /// <param name="sector"></param>
    private void ValidateManageTeamData(string sector)
    {
        InvalidEntityDataException.When(string.IsNullOrEmpty(sector),
            BadInternalOrdersEnum.SectorIsNull.ToString());

        InvalidEntityDataException.When(sector.Length < 5,
            BadInternalOrdersEnum.LongSector.ToString());

        InvalidEntityDataException.When(sector.Length > 30,
            BadInternalOrdersEnum.LongSector.ToString());

        Sector = sector;
        ActiveTeam = true;
    }

    /// <summary>
    /// Inativar Gerenciamento de Equipe
    /// </summary>
    public void InactvateTeam()
    {
        ActiveTeam = false;
    }
}
