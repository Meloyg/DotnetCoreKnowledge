namespace EFCoreKnowledge.Entities.Models;

public record Student
{
    public Guid Id { get; init; }
    public string Name { get; init; }
    public int Age { get; init; }
    public bool IsRegularStudent { get; init; }
    
    public void ValidateState()
    {
        if (string.IsNullOrWhiteSpace(Name))
        {
            throw new ArgumentException("Name is required");
        }
    }
}