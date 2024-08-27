using EFCoreKnowledge.Entities.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace EFCoreKnowledge.Api.Interceptors;

public class AuditableEntitiesInterceptor(ILogger<AuditableEntitiesInterceptor> logger, TimeProvider timeProvider) : SaveChangesInterceptor
{
    public override ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData, InterceptionResult<int> result,
        CancellationToken cancellationToken = new CancellationToken())
    {
        if (eventData.Context is not null)
        {
            logger.LogInformation("Auditing entities.");
            
            foreach (var entry in eventData.Context.ChangeTracker.Entries<IAuditableEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.AuditCreation(timeProvider);
                        break;
                    case EntityState.Modified:
                        entry.Entity.AuditModification(timeProvider);
                        break;
                    default:
                        continue;
                }
            }
        }
        return base.SavingChangesAsync(eventData, result, cancellationToken);
    }
}