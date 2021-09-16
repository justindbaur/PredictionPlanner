using System.Security.Claims;

namespace PredictionPlanner.Server.Common;

public static class ClaimsPrincipalExtensions
{
    public static Guid GetUserId(this ClaimsPrincipal claimsPrincipal)
    {
        var claim = claimsPrincipal.FindFirst(ClaimTypes.NameIdentifier);

        if (claim == null)
        {
            throw new InvalidOperationException("ClaimsPrincipal does not contain nameidentifier, user may not be authenticated.");
        }

        return Guid.Parse(claim.Value);
    }
}