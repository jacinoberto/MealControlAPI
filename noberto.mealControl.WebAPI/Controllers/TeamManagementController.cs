using Microsoft.AspNetCore.Mvc;
using noberto.mealControl.Application.DTOs.TeamManagement;
using noberto.mealControl.Application.Interfaces;

namespace noberto.mealControl.WebAPI.Controllers;

[Route("api/team-management")]
[ApiController]
public class TeamManagementController : ControllerBase
{
    private readonly ITeamManagementService _service;

    public TeamManagementController(ITeamManagementService service)
    {
        _service = service;
    }

    /// <summary>
    /// Cadastra um novo Gerenciamento de Equipe no sistema.
    /// </summary>
    /// <param name="teamManagementDto"></param>
    /// <returns>IActionResult</returns>
    /// <returns code="201">Caso o cadastro do Gerenciamento de Equipe ocorra com sucesso.</returns>
    /// <returns code="400">Caso ocorra um erro do lado do cliente ao preencher os informações.</returns>
    /// <returns code="500">Caso sejam atribuidos Obras e Setores duplicados ao Encarregado.</returns>
    [HttpPost("create")]
    public async Task<IActionResult> CreateTeamManagementAsync([FromBody] CreateTeamManagementDTO teamManagementDto)
    {
        await _service.CreateTeamManagementAsync(teamManagementDto);
        return StatusCode(201);
    }

    /// <summary>
    /// Retorna uma lista de Gerenciamento de Equipes do estado informado.
    /// </summary>
    /// <param name="state"></param>
    /// <returns>IActionResult</returns>
    /// <returns code="200">Caso sejam encontrados Gerencimentos de Equipes compativeis com o estado informado.</returns>
    /// <returns code="404">Caso não sejam encontrados Gerencimentos de Equipes compativeis com o estado informado.</returns>
    [HttpGet("search-by-state")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetTeamManagementByState([FromQuery] string state)
    {
        return Ok(await _service.GetTeamsManagementByStateAsync(state));
    }

    /// <summary>
    /// Inativa o Gerenciamento de Equipe.
    /// </summary>
    /// <param name="teamManagementId"></param>
    /// <returns>IActionResult</returns>
    /// <returns code="204">Caso um Gerenciamento de Equipe seja inativado com sucesso.</returns>
    /// <returns code="404">Caso o Gerenciamento de Equipe não seja encontrado pelo ID informado.</returns>
    [HttpDelete("inactivate-team/{teamManagementId}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> InactivateTeamManagementAsync(Guid teamManagementId)
    {
        await _service.DisableTeamManagementAsync(teamManagementId);
        return NoContent();
    }
}
