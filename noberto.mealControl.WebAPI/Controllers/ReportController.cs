using Microsoft.AspNetCore.Mvc;
using noberto.mealControl.Application.Interfaces;

namespace noberto.mealControl.WebAPI.Controllers;

[Route("api/report")]
[ApiController]
public class ReportController : ControllerBase
{
    private readonly IReportService _service;

    public ReportController(IReportService service)
    {
        _service = service;
    }

    /// <summary>
    /// Retorna os dados do Relatório com os devidos valores e quantidades das refeições.
    /// </summary>
    /// <param name="startDate"></param>
    /// <param name="closingDate"></param>
    /// <param name="managerId"></param>
    /// <returns>IActionResult</returns>
    /// <return code="200">Se O relatório for gerado com sucesso.</return>
    [HttpGet]
    public async Task<IActionResult> GetReportByStartDateAndClosingDateAndManagerId([FromQuery] DateOnly startDate, [FromQuery] DateOnly closingDate, [FromQuery] Guid managerId)
    {
        return Ok(await _service.GetReportsByStartDateAndClosingDateAndManagerId(startDate, closingDate, managerId));
    }
}
