using EFCoreKnowledge.Entities.Interfaces;

namespace EFCoreKnowledge.Entities.Models;

public class Student : IAuditableEntity
{
    public Guid Id { get; init; }
    public string Name { get; init; }
    public int Age { get; init; }
    public bool IsRegularStudent { get; init; }
    public DateTime Created { get; private set; }
    public DateTime Modified { get; private set; }

    public void AuditCreation(TimeProvider timeProvider)
    {
        var now = timeProvider.GetUtcNow().UtcDateTime;
        Created = now;
        Modified = now;
    }

    public void AuditModification(TimeProvider timeProvider)
    {
        Modified = timeProvider.GetUtcNow().UtcDateTime;
    }

    public void ValidateState()
    {
        if (string.IsNullOrWhiteSpace(Name))
        {
            throw new ArgumentException("Name is required");
        }
    }
}