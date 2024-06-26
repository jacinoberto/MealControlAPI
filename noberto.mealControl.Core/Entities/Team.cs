namespace noberto.mealControl.Core.Entities;

public class Team : Identifier
{
    public bool ActiveTeam { get; private set; }

    public Guid AdministratorId { get; set; }
    public Guid TeamManagementId { get; set; }
    public Guid WorkerId { get; set; }
    public Administrator Administrator { get; set; }
    public TeamManagement TeamManagement { get; set; }
    public Worker Worker { get; set; }

    public IEnumerable<Meal> Meals { get; set; }

    public Team()
    {
        ActiveTeam = true;
    }

    /// <summary>
    /// Inativar Equipe
    /// </summary>
    public void InactivateTeam()
    {
        ActiveTeam = false;
    }
}
