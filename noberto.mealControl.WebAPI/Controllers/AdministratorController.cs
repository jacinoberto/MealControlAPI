using Microsoft.AspNetCore.Mvc;
using noberto.mealControl.Application.DTOs.AdministratorDTO;
using noberto.mealControl.Application.Interfaces;

namespace noberto.mealControl.WebAPI.Controllers;

[Route("api/administrator")]
[ApiController]
public class AdministratorController : ControllerBase
{
    private readonly IAdministratorService _service;

    public AdministratorController(IAdministratorService service)
    {
        _service = service;
    }

    /// <summary>
    /// Cadastra um administrador no sistema.
    /// </summary>
    /// <param name="administratorDto"></param>
    /// <returns>IActionResult</returns>
    /// <response code="201">Caso o cadastro ocorra com sucesso.</response>
    /// <response code="400">Caso ocorra um erro do lado do cliente.</response>
    /// <response code="500">Caso seja informado uma Matricula ou E-mail já cadastrado no sistema.</response>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> CreateAdministratorAsync(CreateAdministratorDTO administratorDto)
    {
        var resultado = await _service.CreateAdministratorAsync(administratorDto);
        return StatusCode(201);
    }

    /// <summary>
    /// Altera a senha de acesso de um determinado Administrador pelo seu Id.
    /// </summary>
    /// <param name="administratorId"></param>
    /// <param name="recoverPasswordDto"></param>
    /// <returns>IActionResult</returns>
    /// <response code="200">Caso a senha do Administrador seja alterada com sucesso</response>
    /// <response code="404">Caso o Administrador não seja encontrado</response>
    [HttpPatch("/recover-password/{administratorId}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> RecoverAdministratorPasswordAsync(Guid administratorId, [FromBody] RecoverAdministratorPasswordDTO recoverPasswordDto)
    {
        await _service.RecoverAdministratorPasswordAsync(administratorId, recoverPasswordDto);
        return Ok();
    }

    /// <summary>
    /// Desativa o perfil de um determinado Administrador pelo seu Id.
    /// </summary>
    /// <param name="administratorId"></param>
    /// <returns>IActionResult</returns>
    /// <response code="204">Caso o perfil do Administrador sejai inativado</response>
    /// <response code="404">Caso o Administrador não seja encontrado</response>
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [HttpDelete("/inactivate-profile/{administratorId}")]
    public async Task<IActionResult> InactivateAdministratorProfile(Guid administratorId)
    {
        await _service.InactivateAdministratorProfileAsync(administratorId);
        return NoContent();
    }
}
