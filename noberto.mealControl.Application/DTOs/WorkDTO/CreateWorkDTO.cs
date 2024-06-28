using noberto.mealControl.Application.DTOs.AddressDTO;
using System.ComponentModel.DataAnnotations;

namespace noberto.mealControl.Application.DTOs.WorkDTO;

public record struct CreateWorkDTO(
    [Required(ErrorMessage = "A Identificação é obrigatória.")]
    [StringLength(30, ErrorMessage = "Identificação invalida, o maxímo de caracteres permitidos são 30.")]
    [MinLength(3, ErrorMessage = "Identificação invalida, o minímo de caracteres permitidos são 3.")]
    string Identification,

    [Required(ErrorMessage = "A Data Inicial é obrigatória.")]
    DateOnly StartDate,

    CreateAddressDTO Address
    );
