using Microsoft.EntityFrameworkCore;
using Evaluacion.Server.Data;
using Evaluacion.Server.Dtos;

namespace Evaluacion.Server.Services;

public class ClientsService(AppDbContext context) : IClientsService
{
  public async Task<List<ClientDto>> GetClientsAsync(string? nameFilter, CancellationToken cancellationToken = default)
  {
    nameFilter = string.IsNullOrWhiteSpace(nameFilter) ? null : nameFilter.Trim();

    var query = context.Clients
      .AsNoTracking()
      .AsQueryable();

    if (nameFilter is not null)
    {
      query = query.Where(c => c.Name.Contains(nameFilter));
    }

    return await query
      .OrderByDescending(c => c.CategoryId)
      .ThenBy(c => c.Name)
      .Select(c => new ClientDto
      {
        Id = c.Id,
        Name = c.Name,
        Phone = c.Phone,
        Country = c.Country,
        CategoryId = c.CategoryId
      })
      .ToListAsync(cancellationToken);
  }
}

