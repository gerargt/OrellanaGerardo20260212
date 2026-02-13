### 1. Configurar proyectos de inicio múltiples (recomendado)

Para que se ejecuten el cliente y el servidor al pulsar **Iniciar (F5)**:

1. En el **Explorador de soluciones**, clic derecho en la **Solución**.
2. Selecciona **Configurar proyectos de inicio** (o **Set Startup Projects**).
3. Elige **Proyectos de inicio múltiples**.
4. Para **Evaluacion.Service** y **Evaluation.Site**, establece la acción en **Iniciar**.
5. Asegúrate de que **Evaluacion.Service** quede arriba en la lista para que el API arranque primero (opcional pero recomendado).
6. Pulsa **Aceptar**.

Así, al ejecutar la solución se iniciarán **Client + Server** a la vez.

### 2. Ejecutar la aplicación

- Pulsa **F5** o el botón **Iniciar** para ejecutar en modo depuración.
- O **Ctrl+F5** para ejecutar sin depurar.

El cliente Angular se sirve normalmente por el proxy del servidor (por ejemplo, `https://localhost:60272` o el puerto configurado en el proyecto). La API estará disponible en la misma base o en el puerto indicado en `launchSettings.json`.

## Estructura de la solución

| Proyecto              | Descripción                    |
|-----------------------|--------------------------------|
| **Evaluacion.Service** | API ASP.NET Core (backend)     |
| **Evaluation.Site**    | Aplicación Angular (frontend)   |

## Notas

- La URL base de la API para el cliente está en `Evaluation.Site/src/environments/environment.ts` (por ejemplo, `https://localhost:60272`). Debe coincidir con la URL del servidor en `Evaluacion.Service/Properties/launchSettings.json`.
- Si cambias el puerto del servidor, actualiza también `apiBaseUrl` en `environment.ts`.
