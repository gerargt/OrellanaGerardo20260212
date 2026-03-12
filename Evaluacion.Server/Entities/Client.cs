namespace Evaluacion.Server.Entities;

public class Client : BaseEntity
{
  public string Country { get; set; } = null!;
  public string Name { get; set; } = null!;
  public string Phone { get; set; } = null!;
  public int CategoryId { get; set; }
  public virtual Category Category { get; set; } = null!;
}

