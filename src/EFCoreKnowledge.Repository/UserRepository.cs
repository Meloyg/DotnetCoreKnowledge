using EFCoreKnowledge.Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace EFCoreKnowledge.Repository;

public interface IUserRepository
{
    Task<IEnumerable<User>> GetUsersAsync();
}

public class UserRepository(RepositoryContext context) : IUserRepository
{
    public async Task<IEnumerable<User>> GetUsersAsync()
    {
        // AsNoTracking fetches data that is not intended to be changed in the current context.
        // It makes queries faster and more efficient because EF Core does not need to capture tracking information.
        var users = await context.Users.AsNoTracking().ToListAsync();
        
        return users;
    }
    
    public async Task AddTwoUsersAsync(User user1, User user2)
    {
        // Use Batch Saves to Reduce Database Roundtrips
        // When updating or inserting multiple entities, use batch operations to minimize the number of round trips to the database.
        await context.Users.AddRangeAsync(user1, user2);
        await context.SaveChangesAsync();
    }
}