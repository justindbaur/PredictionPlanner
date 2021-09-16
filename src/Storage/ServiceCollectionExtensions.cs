using Microsoft.EntityFrameworkCore;
using PredictionPlanner.Storage;

namespace Microsoft.Extensions.DependencyInjection;

public static class ServiceCollecitonExtensions
{
    public static IServiceCollection AddMainStorage(this IServiceCollection services, string connectionString)
    {
        return services.AddDbContext<MainDbContext>(options =>
        {
            options.UseSqlite(connectionString);
        });
    }
}