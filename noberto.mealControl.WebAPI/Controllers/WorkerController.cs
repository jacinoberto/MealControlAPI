using Microsoft.AspNetCore.Mvc;
using noberto.mealControl.Application.Interfaces;

namespace noberto.mealControl.WebAPI.Controllers;

[Route("api/worker")]
[ApiController]
public class WorkerController : ControllerBase
{
    private readonly IWorkerService _service;

    public WorkerController(IWorkerService service)
    {
        _service = service;
    }

    /// <summary>
    /// Retorna uma lista de Operários pela Matricula ou Nome.
    /// </summary>
    /// <param name="registrationOrName"></param>
    /// <returns>IActionResult</returns>
    /// <returns code="200">Caso sejam retornados Operários compativeis com o dado informado.</returns>
    /// <returns code="404">Caso não sejam encontrados Operários compativeis com o dado informado.</returns>
    [HttpGet("search")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetWorkersByRegistrationOrName(string registrationOrName)
    {
        return Ok(await _service.GetWorkersByRegistrationOrNameAsync(registrationOrName));

    }

    /// <summary>
    /// Inativa o perfil de um Operário.
    /// </summary>
    /// <param name="wokerId"></param>
    /// <returns>IActionRedult</returns>
    /// <returns code="204">Caso o perfil do Operário seja desativado com sucesso.</returns>
    /// <returns code="404">Caso o Operário não seja encontrado.</returns>
    [HttpDelete("deactivate-profile")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DeactivateWorkerProfile(Guid wokerId)
    {
        await _service.InactivateWorkerProfile(wokerId);
        return NoContent();
    }
}
