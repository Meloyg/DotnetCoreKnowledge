using Dotnet.Refit.Models;
using Refit;

namespace Dotnet.Refit.RefitClient;

/// <summary>
/// Refit User client
/// </summary>
public interface IUsersClient
{
    [Get("/users")]
    Task<IEnumerable<User>> GetAllUsersAsync();
}