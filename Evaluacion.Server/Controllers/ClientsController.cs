using Microsoft.AspNetCore.Mvc;
using Evaluacion.Server.Dtos;
using Evaluacion.Server.Services;

namespace Evaluacion.Server.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ClientsController(IClientsService clientsService) : ControllerBase
{

  [HttpGet]
  public async Task<ActionResult<IReadOnlyList<ClientDto>>> Get([FromQuery] string? name = null)
  {
    var clients = await clientsService.GetClientsAsync(name);
    return Ok(clients);
  }
}

