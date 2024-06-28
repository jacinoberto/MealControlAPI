namespace noberto.mealControl.Core.Enums.Impl;

public class TypesOfInternalServerErrorEnum : Enumeration
{
    protected TypesOfInternalServerErrorEnum(double identifier, string description)
        : base(identifier, description) {}

    protected TypesOfInternalServerErrorEnum(string description)
        : base(description) { }

    // Administrator
    public static TypesOfInternalServerErrorEnum DuplicateAdminEmail =
        new("Já existe um administrador cadastrado no sistema com o e-mail informado");

    public static TypesOfInternalServerErrorEnum DuplicateAdminRegistration =
        new("Já existe um administrador cadastrado no sistema com a matricula informada");

    // Manager
    public static TypesOfInternalServerErrorEnum DuplicateManagerEmail =
        new("Já existe um encarregado cadastrado no sistema com o e-mail informado");

    public static TypesOfInternalServerErrorEnum DuplicateManagerRegistration =
        new("Já existe um encarregado cadastrado no sistema com a matricula informada");

    // Worker
    public static TypesOfInternalServerErrorEnum DuplicateWorkerRegistration =
        new("Já existe um operário cadastrado no sistema com a matricula informada");

    public static TypesOfInternalServerErrorEnum InactiveWorker =
        new("O operário informado não está mais ativo no sistema.");

    // Work
    public static TypesOfInternalServerErrorEnum DuplicateWorkIdentification =
        new("Já existe uma obra cadastrada no sistema com a identificação informada");

    // TeamManagement
    public static TypesOfInternalServerErrorEnum InactiveTeamManagement =
        new("O gerenciamento de equipe informado não está mais ativo no sistema.");

    public static TypesOfInternalServerErrorEnum DuplicateTeamManagementSector =
        new("Este encarregado já possuí uma equipe para este setor nesta obra. Um encarregado não poder ter mais de uma equipe no mesmo setor de uma obra.");

    public static TypesOfInternalServerErrorEnum DuplicateTeamManagementWork =
        new("Este encarregado já possuí uma equipe em andamento em outra obra. Um encarregado não poder ter mais de uma equipe obras diferentes.");

    // Team
    public static TypesOfInternalServerErrorEnum InactiveTeam =
        new("A equipe informada não está mais ativa no sistema.");
}
