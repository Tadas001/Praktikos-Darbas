using Microsoft.EntityFrameworkCore;
using Repository;

namespace WebApi;

public static class DbMigration
{
    public static async Task UseDbMigration(this IApplicationBuilder app)
    {
        using var serviceScope = app.ApplicationServices
            .GetRequiredService<IServiceScopeFactory>()
            .CreateScope();

        await using var context = serviceScope.ServiceProvider.GetService<UsersDbContext>();

        await context!.Database.MigrateAsync();
    }
}