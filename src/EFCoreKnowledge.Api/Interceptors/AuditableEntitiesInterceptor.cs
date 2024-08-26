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
            
            
        }
        return base.SavingChangesAsync(eventData, result, cancellationToken);
    }
}