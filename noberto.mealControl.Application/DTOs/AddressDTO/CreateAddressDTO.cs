using System.ComponentModel.DataAnnotations;

namespace noberto.mealControl.Application.DTOs.AddressDTO;

public record struct CreateAddressDTO(
    [Required(ErrorMessage = "O CEP é obrigatório")]
    [StringLength(8, ErrorMessage = "CEP invalido, o maxímo de caracteres permitidos são 8.")]
    [MinLength(8, ErrorMessage = "CEP invalido, o minímo de caracteres permitidos são 8.")]
    string ZipCode,

    [Required(ErrorMessage = "A Rua é obrigatória")]
    [StringLength(50, ErrorMessage = "Rua invalida, o maxímo de caracteres permitidos são 50.")]
    [MinLength(5, ErrorMessage = "Rua invalida, o minímo de caracteres permitidos são 5.")]
    string Street,

    [Required(ErrorMessage = "O Número é obrigatório")]
    int Number,

    [Required(ErrorMessage = "O Bairro é obrigatóri0")]
    [StringLength(50, ErrorMessage = "Bairro invalido, o maxímo de caracteres permitidos são 50.")]
    [MinLength(5, ErrorMessage = "Bairo invalido, o minímo de caracteres permitidos são 5.")]
    string Area,

    [Required(ErrorMessage = "A Cidade é obrigatória")]
    [StringLength(50, ErrorMessage = "Cidade invalida, o maxímo de caracteres permitidos são 50.")]
    [MinLength(5, ErrorMessage = "Cidade invalida, o minímo de caracteres permitidos são 5.")]
    string City,

    [Required(ErrorMessage = "O Estado é obrigatória")]
    [StringLength(2, ErrorMessage = "Estado invalido, o maxímo de caracteres permitidos são 2.")]
    [MinLength(2, ErrorMessage = "Estado invalido, o minímo de caracteres permitidos são 2.")]
    string State,

    [StringLength(100, ErrorMessage = "Complemento invalido, o maxímo de caracteres permitidos são 100.")]
    string? Complement
    );
