using Microsoft.EntityFrameworkCore;
using Evaluacion.Server.Data;
using Evaluacion.Server.Dtos;
using Evaluacion.Server.Entities;

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
      .Select(x => MapToDto(x))
      .ToListAsync(cancellationToken);
  }

  public async Task<ClientDto?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
  {
    var client = await context.Clients
      .AsNoTracking()
      .Include(c => c.Category)
      .FirstOrDefaultAsync(c => c.Id == id, cancellationToken);
    return client is null ? null : MapToDto(client);
  }

  public async Task<ClientDto> CreateAsync(CreateClientDto request, CancellationToken cancellationToken = default)
  {
    var category = await context.Categories.FirstOrDefaultAsync(c => c.Id == request.CategoryId, cancellationToken)
    ?? throw new InvalidOperationException($"Category with id {request.CategoryId} does not exist.");

    var client = new Client
    {
      Country = request.Country.Trim(),
      Name = request.Name.Trim(),
      Phone = request.Phone.Trim(),
      CategoryId = category.Id
    };
    context.Clients.Add(client);
    await context.SaveChangesAsync(cancellationToken);
    await context.Entry(client).Reference(c => c.Category).LoadAsync(cancellationToken);
    return MapToDto(client);
  }

  public async Task<ClientDto?> UpdateAsync(int id, UpdateClientDto request, CancellationToken cancellationToken = default)
  {
    var client = await context.Clients
      .Include(c => c.Category)
      .FirstOrDefaultAsync(c => c.Id == id, cancellationToken)
      ?? throw new InvalidOperationException($"Client with id {id} does not exist.");

    if (request.CategoryId.HasValue)
    {
      var categoryExists = await context.Categories.AnyAsync(c => c.Id == request.CategoryId.Value, cancellationToken);
      if (!categoryExists)
        throw new InvalidOperationException($"Category with id {request.CategoryId} does not exist.");
      client.CategoryId = request.CategoryId.Value;
    }
    if (request.Country is not null)
      client.Country = request.Country.Trim();
    if (request.Name is not null)
      client.Name = request.Name.Trim();
    if (request.Phone is not null)
      client.Phone = request.Phone.Trim();

    await context.SaveChangesAsync(cancellationToken);
    await context.Entry(client).Reference(c => c.Category).LoadAsync(cancellationToken);
    return MapToDto(client);
  }

  public async Task<bool> DeleteAsync(int id, CancellationToken cancellationToken = default)
  {
    var client = await context.Clients.FindAsync([id], cancellationToken);
    if (client is null)
      return false;
    context.Clients.Remove(client);
    await context.SaveChangesAsync(cancellationToken);
    return true;
  }

  private static ClientDto MapToDto(Client x) => new()
  {
    Id = x.Id,
    Country = x.Country,
    Name = x.Name,
    Phone = x.Phone,
    CategoryId = x.CategoryId,
    Category = new CategoryDto { Id = x.Category.Id, Name = x.Category.Name }
  };
}

