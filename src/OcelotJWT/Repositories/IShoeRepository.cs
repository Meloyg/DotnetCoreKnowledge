using OcelotJWT.Models;

namespace OcelotJWT.Repositories;

public interface IShoeRepository
{
    List<Shoe> GetShoes();
    bool DeleteShoe(int id);
}