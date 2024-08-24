using EFCoreKnowledge.Repository;
using Microsoft.EntityFrameworkCore;

namespace EFCoreKnowledge.Api;

public static class MigrationManager
{
    public static WebApplication MigrateDatabase(this WebApplication app)
    {
        using (var scope = app.Services.CreateScope())
        {
            using (var context = scope.ServiceProvider.GetRequiredService<RepositoryContext>())
            {
                try
                {
                    context.Database.Migrate();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
            }
        }
        return app;
    }
}