using Microsoft.EntityFrameworkCore;
using Evaluacion.Server.Entities;

namespace Evaluacion.Server.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
  public DbSet<Client> Clients => Set<Client>();
  public DbSet<Category> Categories => Set<Category>();

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    base.OnModelCreating(modelBuilder);
  }
}

