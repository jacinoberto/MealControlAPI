using Microsoft.AspNetCore.Mvc;
using noberto.mealControl.Application.DTOs.MealDTO;
using noberto.mealControl.Application.Interfaces;

namespace noberto.mealControl.WebAPI.Controllers;

[Route("api/meal")]
[ApiController]
public class MealController : ControllerBase
{
    private readonly IMealService _service;

    public MealController(IMealService service)
    {
        _service = service;
    }

    /// <summary>
    /// Retorna uma lista de cafés das Equipes de um determinado Encarregado.
    /// </summary>
    /// <param name="managerId"></param>
    /// <param name="date"></param>
    /// <returns>IActionResult</returns>
    /// <returns code="200">Caso sejam encontrados cafés compativeis com o ID informado do Encarregado.</returns>
    /// <returns code="404">Caso não sejam encontrados cafés compativeis com o ID informado do Encarregado.</returns>
    [HttpGet("coffee")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetCoffesByManagerIdAndDate(Guid teamManagementId, [FromQuery] DateOnly date)
    {
        return Ok(await _service.GetCoffesByManagerIdAndDate(teamManagementId, date));
    }
    /// <summary>
    /// Retorna uma lista de almoços das Equipes de um determinado Encarregado.
    /// </summary>
    /// <param name="managerId"></param>
    /// <param name="date"></param>
    /// <returns>IActionResult</returns>
    /// <returns code="200">Caso sejam encontradas almoços compativeis com o ID informado do Encarregado.</returns>
    /// <returns code="404">Caso não sejam encontrados almoços compativeis com o ID informado do Encarregado.</returns>
    [HttpGet("lunch")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetLunchesByManagerIdAndDate(Guid teamManagementId, [FromQuery] DateOnly date)
    {
        return Ok(await _service.GetLunchesByManagerIdAndDate(teamManagementId, date));
    }

    /// <summary>
    /// Retorna uma lista de jantas das Equipes de um determinado Encarregado.
    /// </summary>
    /// <param name="managerId"></param>
    /// <param name="date"></param>
    /// <returns>IActionResult</returns>
    /// <returns code="200">Caso sejam encontradas jantas compativeis com o ID informado do Encarregado.</returns>
    /// <returns code="404">Caso não sejam encontradas jantas compativeis com o ID informado do Encarregado.</returns>
    [HttpGet("dinner")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetDinnersByManagerIdAndDate(Guid teamManagementId, [FromQuery] DateOnly date)
    {
        return Ok(await _service.GetDinnersByManagerIdAndDate(teamManagementId, date));
    }

    /// <summary>
    /// Atualiza o estado do cafés
    /// </summary>
    /// <param name="coffeeDto"></param>
    /// <returns>IActionResult</returns>
    /// <returns code="200">Caso a atualização ocorra sem problemas.</returns>
    [HttpPut("update-coffee")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> UpdateCoffee([FromBody] UpdateMealCoffeeDTO coffeeDto)
    {
        var coffee = await _service.UpdateMealCoffeeAsync(coffeeDto);
        return Ok(coffee);
    }

    /// <summary>
    /// Atualiza o estado do almoço
    /// </summary>
    /// <param name="lunchDto"></param>
    /// <returns>IActionResult</returns>
    /// <returns code="200">Caso a atualização ocorra sem problemas.</returns>
    [HttpPut("update-lunch")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> UpdateLunch([FromBody] UpdateMealLunchDTO lunchDto)
    {
        var lunch = await _service.UpdateMealLunchAsync(lunchDto);
        return Ok(lunch);
    }

    /// <summary>
    /// Atualiza o estado da janta
    /// </summary>
    /// <param name="dinnerDto"></param>
    /// <returns>IActionResult</returns>
    /// <returns code="200">Caso a atualização ocorra sem problemas.</returns>
    [HttpPut("update-dinner")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> UpdateDinner([FromBody] UpdateMealDinnerDTO dinnerDto)
    {
        var dinner = await _service.UpdateMealDinnerAsync(dinnerDto);
        return Ok(dinner);
    }
}
