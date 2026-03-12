using Microsoft.AspNetCore.Mvc;
using Evaluacion.Server.Dtos;
using Evaluacion.Server.Services;

namespace Evaluacion.Server.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ClientsController(IClientsService clientsService) : ControllerBase
{
  [HttpGet]
  public async Task<ActionResult<IReadOnlyList<ClientDto>>> Get([FromQuery] string? name = null, CancellationToken cancellationToken = default)
  {
    var clients = await clientsService.GetClientsAsync(name, cancellationToken);
    return Ok(clients);
  }

  [HttpGet("{id:int}")]
  public async Task<ActionResult<ClientDto>> GetById(int id, CancellationToken cancellationToken = default)
  {
    var client = await clientsService.GetByIdAsync(id, cancellationToken);
    if (client is null)
      return NotFound();
    return Ok(client);
  }

  [HttpPost]
  public async Task<ActionResult<ClientDto>> Create([FromBody] CreateClientDto dto, CancellationToken cancellationToken = default)
  {
    try
    {
      var client = await clientsService.CreateAsync(dto, cancellationToken);
      return CreatedAtAction(nameof(GetById), new { id = client.Id }, client);
    }
    catch (InvalidOperationException ex)
    {
      return BadRequest(ex.Message);
    }
  }

  [HttpPut("{id:int}")]
  public async Task<ActionResult<ClientDto>> Update(int id, [FromBody] UpdateClientDto dto, CancellationToken cancellationToken = default)
  {
    try
    {
      var client = await clientsService.UpdateAsync(id, dto, cancellationToken);
      if (client is null)
        return NotFound();
      return Ok(client);
    }
    catch (InvalidOperationException ex)
    {
      return BadRequest(ex.Message);
    }
  }

  [HttpDelete("{id:int}")]
  public async Task<ActionResult> Delete(int id, CancellationToken cancellationToken = default)
  {
    var deleted = await clientsService.DeleteAsync(id, cancellationToken);
    if (!deleted)
      return NotFound();
    return NoContent();
  }
}

