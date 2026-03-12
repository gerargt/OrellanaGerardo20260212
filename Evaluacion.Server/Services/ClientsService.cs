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
      .Include(c => c.Category)
      .AsNoTracking()
      .AsQueryable();

    if (nameFilter is not null)
    {
      query = query.Where(c => c.Name.Contains(nameFilter));
    }

    return await query
      .OrderBy(x => x.Id)
      .ThenBy(x => x.Name)
      .Select(x => new ClientDto
      {
        Id = x.Id,
        Name = x.Name,
        Phone = x.Phone,
        Country = x.Country,
        CategoryId = x.CategoryId,
        Category = new CategoryDto
        {
          Id = x.CategoryId,
          Name = x.Category.Name
        }
      })
      .ToListAsync(cancellationToken);
  }
}

