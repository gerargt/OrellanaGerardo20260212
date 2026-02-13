## Versiones de librerías

Requisito: [.NET SDK 10.0](https://dotnet.microsoft.com/download) instalado.

---

### 1. Configurar proyectos de inicio múltiples (recomendado)

Para que se ejecuten el cliente y el servidor al pulsar **Iniciar (F5)**:

1. En el **Explorador de soluciones**, clic derecho en la **Solución**.
2. Selecciona **Configurar proyectos de inicio** (o **Set Startup Projects**).
3. Elige **Proyectos de inicio múltiples**.
4. Para **Evaluacion.Server** y **Evaluacion.client**, establece la acción en **Iniciar**.
5. Asegúrate de que **Evaluacion.Server** quede arriba en la lista para que el API arranque primero (opcional pero recomendado).
6. Pulsa **Aceptar**.

Así, al ejecutar la solución se iniciarán **Client + Server** a la vez.

### 2. Ejecutar la aplicación

- Pulsa **F5** o el botón **Iniciar** para ejecutar en modo depuración.
- O **Ctrl+F5** para ejecutar sin depurar.

## Notas

- La URL base de la API para el cliente está en `Evaluacion.client/src/environments/environment.ts` (por ejemplo, `https://localhost:60272`). Debe coincidir con la URL del servidor en `Evaluacion.Server/Properties/launchSettings.json`.
- Si cambias el puerto del servidor, actualiza también `apiBaseUrl` en `environment.ts`.
