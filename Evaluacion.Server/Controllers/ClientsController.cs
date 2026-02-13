using Microsoft.AspNetCore.Mvc;
using Evaluacion.Service.Dtos;
using Evaluacion.Service.Data;
using Microsoft.EntityFrameworkCore;

namespace Evaluacion.Service.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ClientsController(AppDbContext context) : ControllerBase
{

  [HttpGet]
  public async Task<ActionResult<List<ClientDto>>> Get([FromQuery] string? name = null)
  {
    var query = context.Clients.AsQueryable();
    if (name != null)
    {
      query = query.Where(c => c.Name.Contains(name));
    }

    query = query.OrderByDescending(c => c.Category).ThenBy(c => c.Name);
    var clients = await query.Select(c => new ClientDto
    {
      Country = c.Country,
      Id = c.Id,
      Name = c.Name,
      Phone = c.Phone,
      Category = c.Category
    }).ToListAsync();

    return Ok(clients);
  }
}
