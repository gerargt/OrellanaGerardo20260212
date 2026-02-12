using Evaluacion.Server.Dtos;

namespace Evaluacion.Server.Services;

public interface IClientsService
{
  Task<List<ClientDto>> GetClientsAsync(string? nameFilter, CancellationToken cancellationToken = default);
}

