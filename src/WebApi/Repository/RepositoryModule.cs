using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Repository;

public static class RepositoryModule
{
    public static IServiceCollection AddRepository(this IServiceCollection services)
    {
        var folder = Environment.SpecialFolder.LocalApplicationData;
        var path = Environment.GetFolderPath(folder);
        var dbPath = Path.Join(path, "users.db");

        services.AddDbContext<UsersDbContext>(options => options.UseSqlite($"Data Source={dbPath}"));

        return services;
    }
}