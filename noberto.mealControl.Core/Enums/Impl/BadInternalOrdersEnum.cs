namespace noberto.mealControl.Core.Enums.Impl;

public class BadInternalOrdersEnum : Enumeration
{
    protected BadInternalOrdersEnum(double identifier, string description)
        : base(identifier, description) {}

    protected BadInternalOrdersEnum(string description)
        : base(description) { }

    //Menssagens de erros para User/Worker
    public static BadInternalOrdersEnum RegistrationIsNull =
        new("O campo matricula é de caráter obrigatório.");

    public static BadInternalOrdersEnum ShortRegistration =
        new("Matricula invalida, quantidade miníma de caracteres permitidos é 9.");

    public static BadInternalOrdersEnum LongRegistration =
        new("Matricula invalida, quantidade de caracteres acima do permitido.");

    public static BadInternalOrdersEnum NameIsNull =
        new("O campo nome é de caráter obrigatório.");

    public static BadInternalOrdersEnum ShortName =
        new("Nome invalido, quantidade miníma de caracteres permitidos é 3.");

    public static BadInternalOrdersEnum LongName =
        new("Nome invalido, quantidade de caracteres acima do permitido.");

    public static BadInternalOrdersEnum EmailIsNull =
        new("O campo e-mail é de caratere obrigatório.");

    public static BadInternalOrdersEnum LongEmail =
        new("E-mail invalido, quantidade de caracteres acima do permitido.");

    public static BadInternalOrdersEnum PasswordIsNull =
        new("O campo senha é obrigatório.");

    //Menssagens de erros para Address
    public static BadInternalOrdersEnum ZipCodeIsNull =
        new("O campo CEP é obrigatório.");

    public static BadInternalOrdersEnum ShortZipCode =
        new("CEP invalido, quantidade miníma de caracteres permitidos é 8.");

    public static BadInternalOrdersEnum LongZipCode =
        new("CEP invalido, quantidade de caracteres acima do permitido.");

    public static BadInternalOrdersEnum StreetIsNull =
        new("O campo rua é obrigatório.");

    public static BadInternalOrdersEnum ShortStreet =
        new("Rua invalida, quantidade miníma de caracteres é 5.");

    public static BadInternalOrdersEnum LongStreet =
        new("Rua invalida, quantidade de caracteres acima do permitido.");

    public static BadInternalOrdersEnum NumberIsNull =
        new("O campo número é obrigatório.");

    public static BadInternalOrdersEnum NegativeNumber =
        new("Número invalido, seu valor não pode ser negativo.");

    public static BadInternalOrdersEnum AreaIsNull =
        new("O campo bairro é obrigatório.");

    public static BadInternalOrdersEnum ShortArea =
        new("Bairro invalido, quantidade miníma de caracteres é 5.");

    public static BadInternalOrdersEnum LongArea =
        new("Bairro invalido, quantidade de caracteres acima do permitido.");

    public static BadInternalOrdersEnum CityIsNull =
        new("O campo cidade é obrigatório.");

    public static BadInternalOrdersEnum ShortCity =
        new("Cidade invalida, quantidade miníma de caracteres é 5.");

    public static BadInternalOrdersEnum LongCity =
        new("Cidade invalida, quantidade de caracteres acima do permitido.");

    public static BadInternalOrdersEnum StateIsNull =
        new("O campo estado é obrigatório.");

    public static BadInternalOrdersEnum ShortState =
        new("Estado invalido, quantidade miníma de caracteres é 2.");

    public static BadInternalOrdersEnum LongState =
        new("Estado invalido, quantidade de caracteres acima do permitido.");

    public static BadInternalOrdersEnum LongComplement =
        new("Complemento invalido, quantidade de caracteres acima do permitido.");

    //Mensagens de erro para Work
    public static BadInternalOrdersEnum IdentificationIsNull =
        new("O campo identificação é obrigatório.");

    public static BadInternalOrdersEnum LongIdentification =
        new("Identificação invalida, quantidade de caracteres acima do permitido.");

    public static BadInternalOrdersEnum ShortIdentification =
        new("Identificação invalida, quantidade miníma de caracteres é 3.");

    public static BadInternalOrdersEnum StartDateIsNull =
        new("O campo data de abertura é obrigatório.");

    public static BadInternalOrdersEnum PastStartDate =
        new("A data de início da obra precisa ser uma data futura.");

    public static BadInternalOrdersEnum AddressIsNull =
        new("O campo endereço é obrigatório.");

    //Mensagens de erro para ManageTeam
    public static BadInternalOrdersEnum SectorIsNull =
        new("O campo setor é obrigatório.");

    public static BadInternalOrdersEnum ShortSector =
        new("Setor invalido, quantidade miníma de caracteres é 3.");

    public static BadInternalOrdersEnum LongSector =
        new("Setor invalido, quantidadee de caracteres acima do permitido.");

    //Mensagens de erro para ScheduleEvent
    public static BadInternalOrdersEnum MealDateIsNull =
        new("O campo data é obrigatório.");

    public static BadInternalOrdersEnum PastMealDate =
        new("A data atipica precisa ser uma data futura.");

    public static BadInternalOrdersEnum DescriptionIsNull =
        new("O campo descrição é obrigatório.");

    public static BadInternalOrdersEnum ShortDescription =
        new("Descrição invalida, quantidade miníma de caracteres é 5.");

    public static BadInternalOrdersEnum LongDescription =
        new("Descrição invalida, quantidade de caracteres acima do permitido.");

    //Menssagens de erro para Meal
    public static BadInternalOrdersEnum CoffeIsNull =
        new("O campo café é obrigatório.");

    public static BadInternalOrdersEnum LunchIsNull =
        new("O campo almoço é obrigatório.");

    public static BadInternalOrdersEnum DinnerIsNull =
        new("O campo jantar é obrigatório.");
}
