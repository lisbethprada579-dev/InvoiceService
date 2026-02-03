# Invoice Service (Microservicio de Facturas) 

**Descripción**

Microservicio en **ASP.NET Core** que permite registrar y buscar facturas en **SQL Server** usando *stored procedures* (sin Entity Framework). Incluye autenticación JWT, documentación con **Swagger** y endpoints RESTful para crear y consultar facturas.

---

##  Requisitos mínimos

- .NET SDK 10 (ver `dotnet --info`)
- SQL Server (SQL Server, Express o LocalDB)
- `sqlcmd` o un cliente como SQL Server Management Studio / Azure Data Studio
- Puerto HTTP/HTTPS libres (p. ej. según `Properties/launchSettings.json` usa 5022/7106)

---

## Estructura principal del proyecto

- `Controllers/` - `AuthController`, `InvoiceController`
- `Data/` - `IInvoiceRepository`, `InvoiceRepository` (usa `Microsoft.Data.SqlClient`)
- `Database/setup.sql` - script para crear BD, tabla e *stored procedures*
- `Helpers/JwtHelper.cs` - generación de tokens JWT
- `appsettings.json` - ConnectionStrings, Jwt
- `Program.cs` - configuración de DI, autenticación y Swagger

---

## 🔧 Preparar la base de datos

1. Ejecutar el script `Database/setup.sql` en el servidor SQL.
   - Con `sqlcmd` (SQL Server local):

```powershell
sqlcmd -S localhost -E -i Database\setup.sql
```

   - Con LocalDB:

```powershell
sqlcmd -S (localdb)\MSSQLLocalDB -i Database\setup.sql
```

2. Comprobar que existe la base `InvoiceDB` y la tabla `Invoices`:

```sql
SELECT TOP 10 * FROM InvoiceDB.dbo.Invoices;
```

> Nota: el script crea los stored procedures: `sp_CreateInvoice`, `sp_GetInvoiceById`, `sp_GetInvoicesByClient` e índice `IX_Invoices_ClientName`.

---

## Configuración

1. Revisar `appsettings.json` y ajustar `ConnectionStrings:DefaultConnection` si tu instancia SQL usa otro servidor o credenciales:

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=localhost;Database=InvoiceDB;Trusted_Connection=True;TrustServerCertificate=True;"
}
```

2. Asegúrate de tener la sección `Jwt` con `Key` e `Issuer`:

```json
"Jwt": {
  "Key": "THIS_IS_A_SUPER_SECRET_KEY_12345",
  "Issuer": "InvoiceService"
}
```

> Importante: no usar claves duras en producción; usar secretos/KeyVault.

---

##  Ejecutar la aplicación

En la raíz del proyecto:

```bash
dotnet build
dotnet run
```

- Swagger disponible en: `https://localhost:7106/swagger` o `http://localhost:5022/swagger` (según `launchSettings.json`).

---

## 🧭 Endpoints

1. **POST /invoice** (Autorizado)
   - Descripción: Crea una factura y retorna `201 Created` con `{ id }`.
   - Body (JSON):

```json
{
  "clientName": "Juan",
  "amount": 100.5,
  "issueDate": "2026-02-03T00:00:00"
}
```

   - Respuestas:
     - `201 Created` → `{ "id": 1 }`
     - `400 Bad Request` → datos inválidos

2. **GET /invoice/{id}** (Autorizado)
   - Descripción: Retorna la factura por `id`.
   - Respuestas:
     - `200 OK` → factura
     - `404 Not Found` → cuando no existe

3. **GET /invoice/search?client={clientName}** (Autorizado)
   - Descripción: Retorna facturas coincidentes con `clientName` (LIKE %client%).
   - Respuesta: `200 OK` → lista de facturas (puede ser vacía)

4. **POST /auth/login** (No autorizado)
   - Descripción: Endpoint que genera un token JWT de prueba.
   - Respuesta: `200 OK` → `{ "token": "<jwt>" }`

---

## 🔐 Autenticación

- Todos los endpoints de `invoice` están protegidos con **JWT Bearer**.
- Obtener token con `POST /auth/login` y usar header:

```
Authorization: Bearer <token>
```

- En Swagger usar el botón **Authorize** y pegar `Bearer <token>`.

---

## 🧪 Pruebas manuales (curl)

1. Obtener token:

```bash
curl -k -X POST https://localhost:7106/auth/login
```

2. Crear factura:

```bash
curl -k -X POST https://localhost:7106/invoice \
  -H "Authorization: Bearer <token>" \
  -H "Content-Type: application/json" \
  -d '{"clientName":"Juan","amount":100.5,"issueDate":"2026-02-03T00:00:00"}'
```

3. Consultar factura:

```bash
curl -k https://localhost:7106/invoice/1 -H "Authorization: Bearer <token>"
```

---

##  Buenas prácticas y consideraciones

- Validar y sanitizar datos entrantes (el controlador ya valida `ModelState`).
- Manejar excepciones y devolver respuestas significativas (`404`, `400`, `500`).
- No almacenar secretos en el repo; usar variables de entorno o Secret Manager.
- Para entornos de CI, usar una instancia de SQL en contenedor (Docker) o base de datos de pruebas.

---

## 🔁 Stored Procedures & Acceso a datos

- La capa `InvoiceRepository` ejecuta los stored procedures mediante `SqlCommand` y `Microsoft.Data.SqlClient`.
- Ventaja: control total sobre consultas y rendimiento, indexación manual, y cumplimiento del requisito de no usar EF.

---

## Probar / CI (sugerencia)

- No hay tests automáticos en el repo actualmente. Para añadir pruebas de integración:
  1. Crear un proyecto de pruebas con xUnit.
  2. Usar `Microsoft.AspNetCore.Mvc.Testing` y `WebApplicationFactory`.
  3. Preparar la BD de pruebas ejecutando `setup.sql` en el `SetUp` de los tests o usar Dockerized SQL Server.

---

## Troubleshooting

- Error de conexión a SQL: verifica `DefaultConnection` y que el servidor esté en ejecución.
- `Jwt:Key` ausente → excepción al iniciar; añade la clave en `appsettings.json` o en secretos.
- Swagger no muestra endpoints protegidos hasta que se autorice con token.

---

##  Licencia

Proyecto de ejemplo — ajustar según necesidades.

