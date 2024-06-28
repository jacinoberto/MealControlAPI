using noberto.mealControl.Application.DTOs.AddressDTO;
using System.ComponentModel.DataAnnotations;

namespace noberto.mealControl.Application.DTOs.AdministratorDTO;

public record struct CreateAdministratorDTO(
    [Required(ErrorMessage = "A Matricula é obrigatória.")]
    [StringLength(9, ErrorMessage = "Matricula invalida, o maxímo de caracteres permitidos são 9.")]
    [MinLength(9, ErrorMessage = "Matricula invalida, o minímo de caracteres permitidos são 9.")]
    string Registration,

    [Required(ErrorMessage = "O Nome é obrigatório.")]
    [StringLength(100, ErrorMessage = "Nome invalido, o maxímo de caracteres permitidos são 100.")]
    [MinLength(3, ErrorMessage = "Nome invalido, o minímo de caracteres permitidos são 3.")]
    string Name,

    [Required(ErrorMessage = "O E-mail é obrigatório.")]
    [StringLength(150, ErrorMessage = "E-mail invalido, o maxímo de caracteres permitidos são 150.")]
    string Email,

    [Required(ErrorMessage = "A Senha é obrigatória.")]
    string Password,

    CreateAddressDTO Address
    );
