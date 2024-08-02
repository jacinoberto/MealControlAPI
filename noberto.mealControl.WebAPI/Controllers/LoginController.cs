using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using noberto.mealControl.Application.DTOs.ManagerDTO;
using noberto.mealControl.Application.Interfaces;

namespace noberto.mealControl.WebAPI.Controllers;

[Route("api/login")]
[ApiController]
public class LoginController : ControllerBase
{
    private readonly IManagerService _managerService;

    public LoginController(IManagerService managerService)
    {
        _managerService = managerService;
    }

    [HttpPost("manager")]
    public async Task<IActionResult> LoginManager([FromBody] LoginManagerDTO loginManagerDTO)
    {
        return Ok(await _managerService.GetManagerByEmailAndPasswordAsync(loginManagerDTO));
    }
}
