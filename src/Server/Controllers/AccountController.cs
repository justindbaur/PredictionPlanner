using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PredictionPlanner.Server.Services;

namespace PredictionPlanner.Server.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class AccountController : ControllerBase
{
    private readonly IAccountService _accountService;

    public AccountController(IAccountService accountService)
    {
        _accountService = accountService;
    }

    [HttpPost("Register")]
    [AllowAnonymous]
    public async Task<IActionResult> Register(RegisterModel registerModel)
    {
        var user = await _accountService.FindByEmail(registerModel.Email);

        if (user != null)
        {
            ModelState.AddModelError("UserAlreadyExists", "A user by that email already exists.");
            return BadRequest(ModelState);
        }

        user = await _accountService.CreateUserAsync(registerModel.Email, registerModel.PasswordHash);

        return Created("", null);
    }
}
