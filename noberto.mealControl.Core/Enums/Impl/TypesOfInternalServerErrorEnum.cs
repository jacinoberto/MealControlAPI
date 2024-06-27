namespace noberto.mealControl.Core.Enums.Impl;

public class TypesOfInternalServerErrorEnum : Enumeration
{
    protected TypesOfInternalServerErrorEnum(double identifier, string description)
        : base(identifier, description) {}

    protected TypesOfInternalServerErrorEnum(string description)
        : base(description) { }

    public static TypesOfInternalServerErrorEnum DuplicateAdminEmail =
        new("Já existe um administrador cadastrado no sistema com o e-mail informado:");

    public static TypesOfInternalServerErrorEnum DuplicateAdminRegistration =
        new("Já existe um administrador cadastrado no sistema com a matricula informada:");

    public static TypesOfInternalServerErrorEnum DuplicateManagerEmail =
        new("Já existe um encarregado cadastrado no sistema com o e-mail informado:");

    public static TypesOfInternalServerErrorEnum DuplicateManagerRegistration =
        new("Já existe um encarregado cadastrado no sistema com a matricula informada:");
}
