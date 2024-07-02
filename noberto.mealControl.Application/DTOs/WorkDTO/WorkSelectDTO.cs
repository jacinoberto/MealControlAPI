using noberto.mealControl.Application.DTOs.AddressDTO;

namespace noberto.mealControl.Application.DTOs.WorkDTO;

public record struct WorkSelectDTO(
    Guid Id,
    string Identification,
    ReturnCityDTO Address
    );
