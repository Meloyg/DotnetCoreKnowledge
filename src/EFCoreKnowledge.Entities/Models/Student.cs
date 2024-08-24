namespace EFCoreKnowledge.Entities.Models;

public record Student
{
    public Guid Id { get; init; }
    public string Name { get; init; }
    public int Age { get; init; }
    public bool IsRegularStudent { get; init; }
}