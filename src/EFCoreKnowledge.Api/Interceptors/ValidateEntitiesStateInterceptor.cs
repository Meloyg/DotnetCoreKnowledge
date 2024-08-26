using EFCoreKnowledge.Entities.Models;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace EFCoreKnowledge.Api.Interceptors;

public class ValidateEntitiesStateInterceptor(ILogger<ValidateEntitiesStateInterceptor> logger) : SaveChangesInterceptor
{
    public override ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData,
        InterceptionResult<int> result,
        CancellationToken cancellationToken = new CancellationToken())
    {
        if (eventData.Context is not null)
        {
            logger.LogInformation("Validating entities state.");
            foreach (var entry in eventData.Context.ChangeTracker.Entries<Student>())
            {
                entry.Entity.ValidateState();
            }
        }

        return base.SavingChangesAsync(eventData, result, cancellationToken);
    }
}