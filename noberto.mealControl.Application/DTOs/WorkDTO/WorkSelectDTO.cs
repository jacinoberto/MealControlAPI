using noberto.mealControl.Application.DTOs.AddressDTO;

namespace noberto.mealControl.Application.DTOs.WorkDTO;

public record struct WorkSelectDTO(
    string Identification,
    ReturnCityDTO Address
    );
