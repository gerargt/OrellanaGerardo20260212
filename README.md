# Evaluación - Cliente y Servidor

Proyecto con aplicación Angular (cliente) y API ASP.NET Core (servidor).

## Requisitos previos

- **Visual Studio 2022** (o posterior) con carga de trabajo “ASP.NET y desarrollo web”
- **.NET SDK 10.0**
- **Node.js** (para el proyecto Angular)
- **SQL Server** (LocalDB o instancia completa), si la aplicación usa base de datos

## Configuración del proyecto en Visual Studio

### 1. Abrir la solución

- Abre Visual Studio.
- **Archivo → Abrir → Proyecto o solución**.
- Navega hasta la carpeta del proyecto y abre **`OrellanaGerardo20260212.slnx`**.

### 2. Restaurar dependencias (primera vez)

**Servidor (API):**

- En el **Explorador de soluciones**, clic derecho en la solución → **Restaurar paquetes NuGet**.

**Cliente (Angular):**

- Abre una terminal en la carpeta `Evaluacion.client` y ejecuta:
  ```bash
  npm install
  ```

### 3. Configurar proyectos de inicio múltiples (recomendado)

Para que se ejecuten el cliente y el servidor al pulsar **Iniciar (F5)**:

1. En el **Explorador de soluciones**, clic derecho en la **Solución** (nodo raíz).
2. Selecciona **Configurar proyectos de inicio** (o **Set Startup Projects**).
3. Elige **Proyectos de inicio múltiples**.
4. Para **Evaluacion.Server** y **Evaluacion.client**, establece la acción en **Iniciar**.
5. Asegúrate de que **Evaluacion.Server** quede arriba en la lista para que el API arranque primero (opcional pero recomendado).
6. Pulsa **Aceptar**.

Así, al ejecutar la solución se iniciarán **Client + Server** a la vez.

### 4. Ejecutar la aplicación

- Pulsa **F5** o el botón **Iniciar** para ejecutar en modo depuración.
- O **Ctrl+F5** para ejecutar sin depurar.

El cliente Angular se sirve normalmente por el proxy del servidor (por ejemplo, `https://localhost:60272` o el puerto configurado en el proyecto). La API estará disponible en la misma base o en el puerto indicado en `launchSettings.json`.

## Estructura de la solución

| Proyecto              | Descripción                    |
|-----------------------|--------------------------------|
| **Evaluacion.Server** | API ASP.NET Core (backend)     |
| **Evaluacion.client** | Aplicación Angular (frontend)   |

## Notas

- La URL base de la API para el cliente está en `Evaluacion.client/src/environments/environment.ts` (por ejemplo, `https://localhost:60272`). Debe coincidir con la URL del servidor en `Evaluacion.Server/Properties/launchSettings.json`.
- Si cambias el puerto del servidor, actualiza también `apiBaseUrl` en `environment.ts`.
