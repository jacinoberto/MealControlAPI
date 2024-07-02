using Microsoft.AspNetCore.Mvc;
using noberto.mealControl.Application.DTOs.TeamDTO;
using noberto.mealControl.Application.Interfaces;

namespace noberto.mealControl.WebAPI.Controllers;

[Route("api/team")]
[ApiController]
public class TeamController : ControllerBase
{
    private readonly ITeamService _service;

    public TeamController(ITeamService service)
    {
        _service = service;
    }

    /// <summary>
    /// Cadastra uma nova Equipe no sistema.
    /// </summary>
    /// <param name="teamDto"></param>
    /// <returns>IActionResult</returns>
    /// <returns code="200">Caso o cadastro da Equipe ocorra com sucesso.</returns>
    /// <returns code="400">Caso ocorra um erro do lado do cliente durante o preenchimento das indormações.</returns>
    [HttpPost("create")]
    public async Task<IActionResult> CreateTeamAsync([FromBody] CreateTeamDTO teamDto)
    {
        await _service.CreateTeamAsync(teamDto);
        return StatusCode(201);
    }

    /// <summary>
    /// Retorna uma lista de Equipes.
    /// </summary>
    /// <param name="managerId"></param>
    /// <returns>IActionResult</returns>
    /// <returns code="200">Caso sejam encontradas Equipes compativeis com o ID informado do Encarregado.</returns>
    /// <returns code="404">Caso não sejam encontradas Equipes compativeis com o ID informado do Encarregado.</returns>
    [HttpGet("{managerId}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetTeamByManagerId(Guid managerId)
    {
        return Ok(await _service.GetTeamByManagerIdAsync(managerId));
    }

    /// <summary>
    /// Inativa a Equipe.
    /// </summary>
    /// <param name="teamId"></param>
    /// <returns>IActionResult</returns>
    /// <returns code="204">Caso a Equipe seja inativada com sucesso.</returns>
    /// <returns code="404">Caso a Equipe não seja encontrada pelo ID informado.</returns>
    [HttpDelete("inactivate-team/{teamId}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> InactivateTeamAsync(Guid teamId)
    {
        await _service.DisableTeamAsync(teamId);
        return NoContent();
    }
}
