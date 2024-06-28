namespace noberto.mealControl.Application.DTOs.AddressDTO;

public record struct ReturnAddressDTO(
    string ZipCode,
    string Street,
    int Number,
    string Area,
    string City,
    string State,
    string Complement
    );
