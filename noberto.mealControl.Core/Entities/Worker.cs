using noberto.mealControl.Core.Enums.Impl;
using noberto.mealControl.Core.Exceptions;

namespace noberto.mealControl.Core.Entities;

public class Worker : Identifier
{
    public string Registration { get; private set; }
    public string Name { get; private set; }
    public bool ActiveProfile { get; set; }

    public IEnumerable<Team> Teams { get; set; }

    public Worker(string registration, string name)
    {
        ValidateWorkerData(registration, name);
    }

    /// <summary>
    /// Validat dados informados para instanciar um novo Operário
    /// </summary>
    /// <param name="registration"></param>
    /// <param name="name"></param>
    private void ValidateWorkerData(string registration, string name)
    {
        InvalidEntityDataException.When(string.IsNullOrEmpty(registration),
            BadInternalOrdersEnum.RegistrationIsNull.ToString());

        InvalidEntityDataException.When(registration.Length < 9,
            BadInternalOrdersEnum.ShortRegistration.ToString());

        InvalidEntityDataException.When(registration.Length > 9,
            BadInternalOrdersEnum.LongRegistration.ToString());

        InvalidEntityDataException.When(string.IsNullOrEmpty(name),
            BadInternalOrdersEnum.NameIsNull.ToString());

        InvalidEntityDataException.When(name.Length < 3,
            BadInternalOrdersEnum.ShortName.ToString());

        InvalidEntityDataException.When(name.Length > 100,
            BadInternalOrdersEnum.LongName.ToString());

        Registration = registration;
        Name = name;
        ActiveProfile = true;
    }

    /// <summary>
    /// Inativar perfil do Operário
    /// </summary>
    public void DeactivateProfile()
    {
        ActiveProfile = false;
    }
}
