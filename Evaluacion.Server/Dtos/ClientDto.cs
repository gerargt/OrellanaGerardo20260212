namespace Evaluacion.Server.Dtos;

public class ClientDto
{
  public int Id { get; set; }
  public string Country { get; set; } = string.Empty;
  public string Name { get; set; } = string.Empty;
  public string Phone { get; set; } = string.Empty;
  public int CategoryId { get; set; }
  public CategoryDto Category { get; set; } = null!;
}

public class CreateClientDto
{
  public string Country { get; set; } = string.Empty;
  public string Name { get; set; } = string.Empty;
  public string Phone { get; set; } = string.Empty;
  public int CategoryId { get; set; }
}

public class UpdateClientDto
{
  public string? Country { get; set; }
  public string? Name { get; set; }
  public string? Phone { get; set; }
  public int? CategoryId { get; set; }
}

