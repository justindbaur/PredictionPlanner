using Microsoft.AspNetCore.Mvc;
using PredictionPlanner.Server.Models.Response;
using PredictionPlanner.Server.Services;

namespace PredictionPlanner.Server.Controllers;

[ApiController]
[Route("[controller]")]
public class UsersController : ControllerBase
{
    private readonly IUserService _userService;

    public UsersController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpGet("{userId}/public-key")]
    public async Task<IActionResult> GetPublicKey(Guid userId)
    {
        var key = await _userService.GetUserPublicKey(userId);

        if (key == null)
        {
            return NotFound();
        }

        return Ok(new PublicKeyResponseModel(key, userId));
    }
}
