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
    /// Retorna uma lista de Refeições das Equipes de um determinado Encarregado.
    /// </summary>
    /// <param name="managerId"></param>
    /// <param name="date"></param>
    /// <returns>IActionResult</returns>
    /// <returns code="200">Caso sejam encontradas compativeis com o ID informado do Encarregado.</returns>
    /// <returns code="404">Caso não sejam encontradas compativeis com o ID informado do Encarregado.</returns>
    [HttpGet("{mangerId}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetMealsByManagerIdAndDate(Guid managerId, [FromQuery] DateOnly date)
    {
        return Ok(await _service.GetMealsByManagerIdAndDate(managerId, date));
    }

    /// <summary>
    /// Atualiza as refeições.
    /// </summary>
    /// <param name="mealsDto"></param>
    /// <returns>IActionResult</returns>
    /// <returns code=""200>Caso as refeições sejam atualizadas com sucesso.</returns>
    [HttpPut]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> UpdateMealsAsync([FromBody] IEnumerable<UpdateMealDTO> mealsDto)
    {
        await _service.UpdateMealsAsync(mealsDto);
        return Ok();
    }
}
