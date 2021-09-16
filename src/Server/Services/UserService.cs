
namespace PredictionPlanner.Server.Services;

public interface IUserService
{
    Task<string?> GetUserPublicKey(Guid userId);
}

public class UserService : IUserService
{
    private readonly MainDbContext _context;

    public UserService(MainDbContext context)
    {
        _context = context;
    }

    public async Task<string?> GetUserPublicKey(Guid userId)
    {
        var user = await _context.Users
            .FirstOrDefaultAsync(u => u.Id == userId);

        if (user == null)
        {
            return null;
        }

        return user.PublicKey;
    }
}
