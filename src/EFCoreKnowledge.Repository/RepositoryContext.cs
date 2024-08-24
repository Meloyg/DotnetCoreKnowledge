using EFCoreKnowledge.Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace EFCoreKnowledge.Repository;

public class RepositoryContext(DbContextOptions<RepositoryContext> options) : DbContext(options)
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new StudentConfiguration());
    }

    public DbSet<Student> Students { get; set; }
}