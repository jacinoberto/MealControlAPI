using noberto.mealControl.Core.Enums.Impl;
using noberto.mealControl.Core.Exceptions;

namespace noberto.mealControl.Core.Entity;

public class User
{
    public string Registration { get; private set; }
    public string Name { get; private set; }
    public string Email { get; private set; }
    public string Password { get; private set; }
    public bool ActiveProfile { get; private set; }

    public User(string registration, string name, string email, string password)
    {
        ValidateUserData(registration, name, email, password);
    }

    /// <summary>
    /// Método para validar os dados do usuário
    /// </summary>
    /// <param name="registration"></param>
    /// <param name="name"></param>
    /// <param name="email"></param>
    /// <param name="password"></param>
    private void ValidateUserData(string registration, string name, string email, string password)
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

        InvalidEntityDataException.When(string.IsNullOrEmpty(email),
            BadInternalOrdersEnum.EmailIsNull.ToString());

        InvalidEntityDataException.When(email.Length > 150,
            BadInternalOrdersEnum.LongEmail.ToString());

        InvalidEntityDataException.When(string.IsNullOrEmpty(password),
            BadInternalOrdersEnum.PasswordIsNull.ToString());

        Registration = registration;
        Name = name;
        Email = email;
        Password = password;
        ActiveProfile = true;
    }

    /// <summary>
    /// Alterar a senha do Usuário
    /// </summary>
    /// <param name="password"></param>
    public void ChangePassword(string password)
    {
        Password = password;
    }

    /// <summary>
    /// Inativar perfil do usuário
    /// </summary>
    public void DeactivateProfile()
    {
        ActiveProfile = false;
    }
}
