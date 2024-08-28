using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using EFCoreKnowledge.Entities.Interfaces;

namespace EFCoreKnowledge.Entities.Models;

[Table("Users")]
public class User : IAuditableEntity
{
    [Key]
    public long Id { get; protected set; }
    
    [Required]
    [MaxLength(256)]
    public string Name { get; set; }
    
    [Required]
    [ConcurrencyCheck] // Optimistic concurrency check
    public string Email { get; set; }
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
        if (string.IsNullOrWhiteSpace(Email))
            throw new ApplicationException("Invalid user state! Email should be provided!");
    }
}