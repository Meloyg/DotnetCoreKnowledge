namespace EFCoreKnowledge.Entities.Interfaces;

public interface IAuditableEntity
{
    public DateTime Created { get; }
    public DateTime Modified { get; }
    void AuditCreation(TimeProvider timeProvider);
    void AuditModification(TimeProvider timeProvider);
}