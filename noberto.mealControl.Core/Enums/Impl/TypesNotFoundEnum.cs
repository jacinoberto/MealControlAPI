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
}
