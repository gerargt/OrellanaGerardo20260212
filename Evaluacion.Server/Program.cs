using Microsoft.EntityFrameworkCore;
using Evaluacion.Server.Data;
using Evaluacion.Server.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

// CORS para el frontend Angular
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
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Application services
builder.Services.AddScoped<IClientsService, ClientsService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseCors("AllowFrontend");

app.UseAuthorization();

app.MapControllers();

app.Run();
