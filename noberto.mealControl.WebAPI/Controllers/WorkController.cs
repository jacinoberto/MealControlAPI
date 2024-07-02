using Microsoft.AspNetCore.Mvc;
using noberto.mealControl.Application.DTOs.WorkDTO;
using noberto.mealControl.Application.Interfaces;

namespace noberto.mealControl.WebAPI.Controllers;

[Route("api/work")]
[ApiController]
public class WorkController : ControllerBase
{
    private readonly IWorkService _service;

    public WorkController(IWorkService service)
    {
        _service = service;
    }

    /// <summary>
    /// Cadastra uma nova Obra no sistema.
    /// </summary>
    /// <param name="workDto"></param>
    /// <returns>IActionResult</returns>
    /// <returns code="201">Caso o cadastro ocorra com sucesso.</returns>
    /// <returns code="400">Caso ocorra um erro do lado do cliente no momento de preencher as informações.</returns>
    /// <returns code="500">Caso seja informada uma Identificação já cadastrada no sistema.</returns>
    [HttpPost("create")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> CreateWorkAsync([FromBody] CreateWorkDTO workDto)
    {
        await _service.CreateWorkAsync(workDto);
        return StatusCode(201);
    }

    /// <summary>
    /// Retorna uma lista de Obras pelo estado.
    /// </summary>
    /// <param name="state"></param>
    /// <returns>IActionResult</returns>
    /// <returns code="200">Caso sejam encontradas Obras compátiveis com o estado informado.</returns>
    /// <returns code="404">Caso não sejam encontradas Obras compativeis com o estado informado.</returns>
    [HttpGet("search-by-state")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetWorksByStateAsync(string state)
    {
        return Ok(await _service.GetWorksByStateAsync(state));
    }

    /// <summary>
    /// Finaliza uma obra.
    /// </summary>
    /// <param name="workId"></param>
    /// <returns>IActionResult</returns>
    /// <returns code="200">Caso a finalização da Obra ocorra com sucesso.</returns>
    /// <returns code="">Caso a Obra não seja encontrada.</returns>
    [HttpPatch("finish")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> FinishWorkAsync(Guid workId)
    {
        await _service.FinishWorkAsync(workId);
        return Ok();
    }
}
