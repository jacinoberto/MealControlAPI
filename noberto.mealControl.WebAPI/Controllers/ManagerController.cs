using Microsoft.AspNetCore.Mvc;
using noberto.mealControl.Application.DTOs.ManagerDTO;
using noberto.mealControl.Application.Interfaces;

namespace noberto.mealControl.WebAPI.Controllers;

[Route("api/manager")]
[ApiController]
public class ManagerController : ControllerBase
{
    private readonly IManagerService _service;

    public ManagerController(IManagerService service)
    {
        _service = service;
    }

    /// <summary>
    /// Cadastra um novo Encarregado no sistema.
    /// </summary>
    /// <param name="managerDto"></param>
    /// <returns>IActionResult</returns>
    /// <returns code="201">Caso o cadastro ocorra com sucesso.</returns>
    /// <returns code="400">Caso ocorra um erro do lado do cliente durante o preenchimento das informações.</returns>
    /// <returns code="500">Caso seja informado dados duplicados, como Matricula e E-mail já cadastrado no sistema.</returns>
    [HttpPost("create")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> CreateManagerAsync([FromBody] CreateManagerDTO managerDto)
    {
        await _service.CreateManagerAsync(managerDto);
        return StatusCode(201);
    }

    /// <summary>
    /// Retorna uma lista de Encarregados ativos.
    /// </summary>
    /// <returns>IActionResult</returns>
    /// <response code="200">Caso sejam encontrados Encarregados ativos no sistema.</response>
    [HttpGet("all")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAllManageAsync()
    {
        return Ok(await _service.GetAllManageAsync());
    }

    /// <summary>
    /// Retorna uma lista de Encarregados pela Matricula, Nome ou E-mail.
    /// </summary>
    /// <param name="registrationOrNameOrEmail"></param>
    /// <param name="state"></param>
    /// <returns>IActionResult</returns>
    /// <response code="200">Caso sejam encontrados Encarregados compátiveis com o dado informado.</response>
    /// <response code="404">Caso não sejam encontrados Encarregados compativeis com o dado informado.</response>
    [HttpGet("search")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetManagerByRegistrationOrNameOrEmailAsync([FromQuery]  string registrationOrNameOrEmail, [FromQuery] string state)
    {        
        return Ok(await _service.GetManagersByRegistrationOrNameOrEmailAsync(
            registrationOrNameOrEmail, state));
    }

    /// <summary>
    /// Retorna uma lista de Encarregados pelo Estado da filial em que trabalham.
    /// </summary>
    /// <param name="state"></param>
    /// <returns>IActionResult</returns>
    /// <response code="200">Caso sejam encontrados Encarregados compátiveis o dado informado.</response>
    /// <response code="404">Caso não sejam encontrados Encarregados compativeis com o dado informado.</response>
    [HttpGet("search-by-state")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetManagerByState([FromQuery] string state)
    {
        return Ok(await _service.GetManagersByStateAsync(state));
    }

    /// <summary>
    /// Recupera a senha de acesso do Encarregado, alterando a atual por uma nova.
    /// </summary>
    /// <param name="managerId"></param>
    /// <param name="recoverPasswordDto"></param>
    /// <returns>IActionResult</returns>
    /// <returns code="200">Caso a senha seja alterada com sucesso.</returns>
    /// <returns code="404">Caso o Encarregado não seja encontrado pelo ID informado.</returns>
    [HttpPatch("recover-password/{managerId}")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> RecoverManagerPassword(Guid managerId, [FromBody] RecoverManagerPasswordDTO recoverPasswordDto)
    {
        await _service.RecoverManagerPassword(managerId, recoverPasswordDto);
        return Ok();
    }

    /// <summary>
    /// Inativa o perfil de um Encarregado do sistema.
    /// </summary>
    /// <param name="managerId"></param>
    /// <returns>IActionResult</returns>
    /// <returns code="204">Caso o perfil seja inativado com sucesso.</returns>
    /// <returns code="404">Caso o Encarregado não seja encontrado pelo ID informado.</returns>
    [HttpDelete("deactivate-profile/{managerId}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> InactivateManagerProfile(Guid managerId)
    {
        await _service.InactivateManagerProfile(managerId);
        return NoContent();
    }
}