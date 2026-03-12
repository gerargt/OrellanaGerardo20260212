using Evaluacion.Server.Dtos;

namespace Evaluacion.Server.Services;

public interface IClientsService
{
  Task<List<ClientDto>> GetClientsAsync(string? nameFilter, CancellationToken cancellationToken = default);
  Task<ClientDto?> GetByIdAsync(int id, CancellationToken cancellationToken = default);
  Task<ClientDto> CreateAsync(CreateClientDto dto, CancellationToken cancellationToken = default);
  Task<ClientDto?> UpdateAsync(int id, UpdateClientDto dto, CancellationToken cancellationToken = default);
  Task<bool> DeleteAsync(int id, CancellationToken cancellationToken = default);
}

