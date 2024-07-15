using Microsoft.AspNetCore.Mvc;
using noberto.mealControl.Application.BackgroundService.Services.OpenCalendar;
using noberto.mealControl.Application.DTOs.ScheduleEventDTO;
using noberto.mealControl.Application.Interfaces;

namespace noberto.mealControl.WebAPI.Controllers;

[Route("api/schedule-event")]
[ApiController]
public class ScheduleEventController : ControllerBase
{
    private readonly IScheduleEventService _service;
    private readonly IOpenCalendar openCalendar;
    public ScheduleEventController(IScheduleEventService service,IOpenCalendar openCalendar)
    {
        _service = service;
        this.openCalendar = openCalendar;
    }

    /// <summary>
    /// Cadastra uma nova Agenda de Evento no sistema.
    /// </summary>
    /// <param name="scheduleEventDTO"></param>
    /// <returns>IActionResult</returns>
    /// <returns code="201">Caso o cadastro de uma Agenda de Evento ocorra com sucesso.</returns>
    /// <returns code="400">Caso ocorra um erro do lado do cliente durante o preenchimento das informações.</returns>
    [HttpPost("create")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> CreateScheduleEventAsync([FromBody] CreateScheduleEventDTO scheduleEventDTO)
    {
        await _service.CreateScheduleEventAsync(scheduleEventDTO);
        return StatusCode(201);
    }

    [HttpPost]
    public async Task<IActionResult> Teste()
    {
        await openCalendar.Open();
        return StatusCode(201);
    }
}
