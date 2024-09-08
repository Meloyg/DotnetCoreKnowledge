using Microsoft.AspNetCore.Mvc;
using OcelotJWT.Repositories;

namespace OcelotJWT.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ShoesController(IShoeRepository shoeRepository) : ControllerBase
{
    [HttpGet]
    public IActionResult Get()
    {
        return Ok(shoeRepository.GetShoes());
    }

    [HttpDelete("{id:int}")]
    public IActionResult Delete(int id)
    {
        var shoeDeleted = shoeRepository.DeleteShoe(id);
        return shoeDeleted ? NoContent() : NotFound();
    }
}