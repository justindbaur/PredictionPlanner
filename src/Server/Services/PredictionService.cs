using PredictionPlanner.Server.Models;

namespace PredictionPlanner.Server.Services;

public interface IPredictionService
{
    Task CreatePredictionAsync(NewPredictionModel newPrediction, Guid userId);
}

public class PredictionService : IPredictionService
{
    public Task CreatePredictionAsync(NewPredictionModel newPrediction, Guid userId)
    {
        var now = DateTimeOffset.UtcNow;
        throw new NotImplementedException();
    }
}