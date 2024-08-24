using EFCoreKnowledge.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCoreKnowledge.Repository;

public class StudentConfiguration: IEntityTypeConfiguration<Student>
{
    public void Configure(EntityTypeBuilder<Student> builder)
    {
        builder.HasData(
            new Student
            {
                Id = Guid.NewGuid(),
                Name = "John Doe",
                Age = 25,
                IsRegularStudent = true
            },
            new Student
            {
                Id = Guid.NewGuid(),
                Name = "Jane Doe",
                Age = 22,
                IsRegularStudent = false
            },
            new Student
            {
                Id = Guid.NewGuid(),
                Name = "John Smith",
                Age = 30,
                IsRegularStudent = true
            }
        );
    }
}