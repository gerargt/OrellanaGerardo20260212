# Evaluacion.Service

API en ASP.NET Core para la gestión de clientes.

## Versiones

- .NET 10
- ASP.NET Core 10
- Entity Framework Core 10.x

## Requisitos

- .NET 10 SDK
- SQL Server (o LocalDB)

## Configuración

1. Cadena de conexión en `appsettings.json` (o `appsettings.Development.json`): clave `ConnectionStrings:DefaultConnection`.
2. Script de base de datos: ejecutar `DB.sql` para crear la base y la tabla.

## Ejecución

```bash
dotnet run
```

Por defecto la API queda en:
- HTTPS: `https://localhost:7245`
- HTTP: `http://localhost:5245`

