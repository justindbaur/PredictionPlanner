using Microsoft.AspNetCore.Mvc;
using PredictionPlanner.Server.Models;
using PredictionPlanner.Server.Services;
using PredictionPlanner.Server.Common;
using Microsoft.AspNetCore.Authorization;

namespace PredictionPlanner.Server.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class PredictionController : ControllerBase
{
    private readonly IPredictionService _predictionService;

    public PredictionController(IPredictionService predictionService)
    {
        _predictionService = predictionService;
    }

    [HttpPost]
    public async Task<IActionResult> CreatePrediction(NewPredictionModel newPredictionModel)
    {
        await _predictionService.CreatePredictionAsync(newPredictionModel, User.GetUserId());
        return Created("", null);
    }

    [HttpGet("{userId}/public-key")]
}
