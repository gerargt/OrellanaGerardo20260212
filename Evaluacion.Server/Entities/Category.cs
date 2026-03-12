namespace Evaluacion.Server.Entities;

public class Category : BaseEntity
{
  public string Name { get; set; } = null!;
  public virtual ICollection<Client> Clients { get; set; } = [];
}
