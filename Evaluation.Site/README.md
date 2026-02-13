# Evaluation.Site

Frontend en Angular para la consulta de clientes.

## Versiones

- Angular 21.x
- TypeScript 5.9.x
- Node.js 20

## Requisitos

- Node.js 20
- npm

## Instalación

```bash
npm install
```

## Ejecución

```bash
npm start
```

La aplicación se abre en `http://localhost:4200`.

## Configuración

- URL del API: `src/environments/environment.ts` → `apiBaseUrl` (por defecto `https://localhost:7245`).

## Estructura principal

- `src/app/views/customer-list` — vista de listado y búsqueda de clientes
- `src/app/api` — servicio de llamadas al backend
