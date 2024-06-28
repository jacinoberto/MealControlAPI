namespace noberto.mealControl.Core.Enums.Impl;

public class TypesNotFoundEnum : Enumeration
{
    protected TypesNotFoundEnum(string description)
        : base(description) {}

    public static TypesNotFoundEnum AdminNotFound =
        new("Não foi encontrado um administrador cadastrado no sistema com o dado informado.");

    //Manager
    public static TypesNotFoundEnum ManagerNotFound =
        new("Não foi encontrado nenhum enecarregado cadastrado, ativo ou disponível para a sua região no sistema com o dado informado.");

    public static TypesNotFoundEnum ManagerNotFoundForTheRegion =
        new("Nenhum encarregado encontrado. Ele pode não está cadastrado, ativo ou disponível para a sua região no sistema.");

    // Worker
    public static TypesNotFoundEnum WorkerNotFound =
        new("Não foram encontrados operários cadastrados ou ativos no sistema pelo dado informado.");
    
    public static TypesNotFoundEnum WorkerNotFoundById =
        new("Não foi encontrado nenhum operário cadastrado ou ativo no sistema pelo ID informado.");

    // Work
    public static TypesNotFoundEnum WorkNotFoundById =
        new("Não foi encontrado nenhuma obra cadastrada ou ativa no sistema pelo ID informado.");

    public static TypesNotFoundEnum WorkNotFoundForTheRegion =
        new("Nenhuma obra foi encontrada pelo estado informado. Pode não haver obras cadastradas, ativas ou disponíveis para a sua região no sistema.");

    // TeamManagement
    public static TypesNotFoundEnum TeamManagementNotFoundById =
        new("Não foi encontrado nenhum gerenciamento de equipe cadastrado ou ativo no sistema pelo ID informado.");

    public static TypesNotFoundEnum TeamManagementNotFoundForTheRegion =
        new("Nenhum gerenciamento de equipe foi encontrado pelo estado informado. Pode não haver gerenciamento de equipes cadastrados, ativos ou disponíveis para a sua região no sistema.");

    // Team
    public static TypesNotFoundEnum TeamNotFoundById =
        new("Não foi encontrado nenhuma equipe cadastrada ou ativa no sistema pelo ID informado.");

    public static TypesNotFoundEnum TeamNotFoundByManagerId =
        new("Não foi encontrado nenhuma equipe cadastrada ou ativa no sistema que estejam vinculadas ao encarregado informado.");

    // Meal
    public static TypesNotFoundEnum MealNotFoundById =
        new("Não foi encontrado nenhuma refeição no sistema pelo ID informado.");

    public static TypesNotFoundEnum MealNotFoundByManagerIdAndDate =
        new("Não foi encontrado refeições vinculadas a equipe do encarregado informado, ou não há refeições no sistema para a data informada");
}
