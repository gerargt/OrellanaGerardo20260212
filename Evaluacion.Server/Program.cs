using Microsoft.EntityFrameworkCore;
using Evaluacion.Server.Data;
using Evaluacion.Server.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddCors(options =>
{
  options.AddPolicy("AllowFrontend",
    policy =>
      policy.WithOrigins("https://localhost:51745", "https://127.0.0.1:51745")
            .AllowAnyHeader()
            .AllowAnyMethod());
});

// DbContext
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"))
    .UseSnakeCaseNamingConvention());

// Application services
builder.Services.AddScoped<IClientsService, ClientsService>();

var app = builder.Build();

app.UseHttpsRedirection();

app.UseCors("AllowFrontend");

app.UseAuthorization();

app.MapControllers();

app.Run();
