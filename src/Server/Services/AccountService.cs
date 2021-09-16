using System.Security.Cryptography;
using Microsoft.EntityFrameworkCore;

namespace PredictionPlanner.Server.Services;

public interface IAccountService
{
    Task<ApplicationUser> CreateUserAsync(string email, string passwordHash);
    Task<ApplicationUser?> FindByEmail(string email);
}

public class AccountService : IAccountService
{
    private readonly MainDbContext _context;

    public AccountService(MainDbContext context)
    {
        _context = context;
    }

    public Task<ApplicationUser?> FindByEmail(string email)
    {
#pragma warning disable CS8619 // Nullability of reference types in value doesn't match target type.
        return _context.Users
            .Where(u => u.NormalizedEmail == email.ToUpper())
            .FirstOrDefaultAsync();
#pragma warning restore CS8619 // Nullability of reference types in value doesn't match target type.
    }

    public async Task<ApplicationUser> CreateUserAsync(string email, string passwordHash)
    {
        var user = new ApplicationUser
        {
            Id = Guid.NewGuid(),
            Email = email,
            NormalizedEmail = email.ToUpper(),
            EmailConfirmed = false,
            PasswordHash = passwordHash,
        };

        // Send welcome email

        await _context.SaveChangesAsync();

        return user;
    }
}
