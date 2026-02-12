using Microsoft.EntityFrameworkCore;
using Evaluacion.Server.Entities;

namespace Evaluacion.Server.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
  public DbSet<Client> Clients => Set<Client>();

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    base.OnModelCreating(modelBuilder);

    modelBuilder.Entity<Client>(entity =>
    {
      entity.ToTable("Clients");

      entity.HasKey(c => new { c.Country, c.Id });

      entity.Property(c => c.Country)
                  .HasMaxLength(100)
                  .IsRequired();

      entity.Property(c => c.Id)
                  .HasMaxLength(50)
                  .IsRequired();

      entity.Property(c => c.Name)
                  .HasMaxLength(150)
                  .IsRequired();

      entity.Property(c => c.Phone)
                  .HasMaxLength(30)
                  .IsRequired();
    });
  }
}

