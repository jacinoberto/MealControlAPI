using noberto.mealControl.Core.Enums.Impl;
using noberto.mealControl.Core.Exceptions;

namespace noberto.mealControl.Core.Entities;

public class Address : Identifier
{
    public string ZipCode { get; private set; }
    public string Street { get; private set; }
    public int Number { get; private set; }
    public string Area { get; private set; }
    public string City { get; private set; }
    public string State { get; private set; }
    public string? Complement { get; private set; }

    public IEnumerable<Administrator> Administrators { get; set; }
    public IEnumerable<Manager> Managers { get; set; }
    public IEnumerable<Work> Works { get; set; }


    public Address(string zipCode, string street, int number, string area, string city,
        string state, string? complement)
    {
        ValidateAddressData(zipCode, street, number, area, city, state, complement);
    }

    /// <summary>
    /// Validat dados informados para instanciar um novo Endereço
    /// </summary>
    /// <param name="zipCode"></param>
    /// <param name="street"></param>
    /// <param name="number"></param>
    /// <param name="area"></param>
    /// <param name="city"></param>
    /// <param name="state"></param>
    /// <param name="complement"></param>
    private void ValidateAddressData(string zipCode, string street, int number, string area,
        string city, string state, string? complement)
    {
        InvalidEntityDataException.When(string.IsNullOrEmpty(zipCode),
            BadInternalOrdersEnum.ZipCodeIsNull.ToString());

        InvalidEntityDataException.When(zipCode.Length < 8,
            BadInternalOrdersEnum.ShortZipCode.ToString());

        InvalidEntityDataException.When(zipCode.Length > 8,
            BadInternalOrdersEnum.LongZipCode.ToString());

        InvalidEntityDataException.When(string.IsNullOrEmpty(street),
            BadInternalOrdersEnum.StreetIsNull.ToString());

        InvalidEntityDataException.When(street.Length < 5,
            BadInternalOrdersEnum.ShortStreet.ToString());

        InvalidEntityDataException.When(street.Length > 50,
            BadInternalOrdersEnum.LongStreet.ToString());

        InvalidEntityDataException.When(number < 0,
            BadInternalOrdersEnum.NegativeNumber.ToString());

        InvalidEntityDataException.When(string.IsNullOrEmpty(area),
            BadInternalOrdersEnum.AreaIsNull.ToString());

        InvalidEntityDataException.When(area.Length < 5,
            BadInternalOrdersEnum.ShortArea.ToString());

        InvalidEntityDataException.When(area.Length > 50,
            BadInternalOrdersEnum.LongArea.ToString());

        InvalidEntityDataException.When(string.IsNullOrEmpty(city),
            BadInternalOrdersEnum.CityIsNull.ToString());

        InvalidEntityDataException.When(city.Length < 5,
            BadInternalOrdersEnum.ShortCity.ToString());

        InvalidEntityDataException.When(city.Length > 50,
            BadInternalOrdersEnum.LongCity.ToString());

        InvalidEntityDataException.When(string.IsNullOrEmpty(state),
            BadInternalOrdersEnum.StateIsNull.ToString());

        InvalidEntityDataException.When(state.Length < 2,
            BadInternalOrdersEnum.ShortState.ToString());

        InvalidEntityDataException.When(state.Length > 2,
            BadInternalOrdersEnum.LongState.ToString());

        InvalidEntityDataException.When(complement?.Length > 100,
            BadInternalOrdersEnum.LongComplement.ToString());

        ZipCode = zipCode;
        Street = street;
        Number = number;
        Area = area;
        City = city;
        State = state;
        Complement = complement;
    }
}
