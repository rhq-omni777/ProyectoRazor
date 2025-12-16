# ?? Configuración y Personalización Avanzada

## ?? Tabla de contenidos

1. [Cadenas de conexión](#cadenas-de-conexión)
2. [Configuración por ambiente](#configuración-por-ambiente)
3. [Personalizar el puerto](#personalizar-el-puerto)
4. [Variables de entorno](#variables-de-entorno)
5. [Logging](#logging)
6. [HTTPS](#https)

---

## Cadenas de conexión

### Archivo: `appsettings.json`

#### SQL Server LocalDB (Predeterminado)
```json
{
  "ConnectionStrings": {
    "UniversityContext": "Server=(localdb)\\mssqllocaldb;Database=UniversityRazorDB;Trusted_Connection=True;MultipleActiveResultSets=true"
  }
}
```

#### SQL Server Express
```json
{
  "ConnectionStrings": {
    "UniversityContext": "Server=localhost\\SQLEXPRESS;Database=UniversityRazorDB;Trusted_Connection=True;MultipleActiveResultSets=true"
  }
}
```

#### SQL Server con autenticación de usuario
```json
{
  "ConnectionStrings": {
    "UniversityContext": "Server=localhost;Database=UniversityRazorDB;User Id=sa;Password=TuContraseña;MultipleActiveResultSets=true"
  }
}
```

#### Azure SQL Database
```json
{
  "ConnectionStrings": {
    "UniversityContext": "Server=tcp:tuservidor.database.windows.net,1433;Initial Catalog=UniversityRazorDB;Persist Security Info=False;User ID=tuusuario;Password=tucontraseña;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"
  }
}
```

---

## Configuración por ambiente

### Estructura de archivos

```
ProyectoRazor/
??? appsettings.json              # Configuración general
??? appsettings.Development.json  # Configuración para desarrollo
??? appsettings.Production.json   # Configuración para producción
??? appsettings.Staging.json      # Configuración para staging
```

### Crear archivo de staging

Crea un archivo `appsettings.Staging.json`:

```json
{
  "ConnectionStrings": {
    "UniversityContext": "Server=staging-server;Database=UniversityRazorDB;Trusted_Connection=False;User Id=staging_user;Password=staging_password;"
  },
  "Logging": {
    "LogLevel": {
      "Default": "Warning",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "staging.example.com"
}
```

### Acceder a la configuración en código

En `Program.cs` o cualquier lugar:

```csharp
var connectionString = builder.Configuration.GetConnectionString("UniversityContext");
var logging = builder.Configuration.GetSection("Logging");
```

---

## Personalizar el puerto

### Opción 1: Archivo `launchSettings.json`

Abre `Properties/launchSettings.json`:

```json
{
  "profiles": {
    "ProyectoRazor": {
      "commandName": "Project",
      "dotnetRunMessages": true,
      "launchBrowser": true,
      "applicationUrl": "https://localhost:7123;http://localhost:5123",
      "environmentVariables": {
        "ASPNETCORE_ENVIRONMENT": "Development"
      }
    }
  }
}
```

Cambia los puertos:
- `7123` ? Tu puerto HTTPS
- `5123` ? Tu puerto HTTP

### Opción 2: Variable de entorno

```bash
set ASPNETCORE_URLS=https://localhost:8000;http://localhost:8001
dotnet run
```

### Opción 3: En Program.cs

```csharp
var app = builder.Build();
app.Urls.Add("https://localhost:7123");
app.Urls.Add("http://localhost:5123");
app.Run();
```

---

## Variables de entorno

### Definir variables de entorno (Windows)

En PowerShell:
```powershell
$env:ASPNETCORE_ENVIRONMENT = "Production"
$env:ConnectionStrings__UniversityContext = "Server=...;Database=..."
dotnet run
```

En CMD:
```cmd
set ASPNETCORE_ENVIRONMENT=Production
set ConnectionStrings__UniversityContext=Server=...;Database=...
dotnet run
```

### En `appsettings.json`

```json
{
  "ConnectionStrings": {
    "UniversityContext": "Server=${DB_SERVER};Database=${DB_NAME};User Id=${DB_USER};Password=${DB_PASSWORD};"
  }
}
```

### Acceder en código

```csharp
var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
var dbServer = Environment.GetEnvironmentVariable("DB_SERVER");
```

---

## Logging

### Configuración por defecto (`appsettings.json`)

```json
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning",
      "Microsoft.EntityFrameworkCore": "Information"
    }
  }
}
```

### Niveles de logging

- **Trace**: Información muy detallada (prácticamente nunca)
- **Debug**: Información de depuración
- **Information**: Información general
- **Warning**: Advertencias
- **Error**: Errores
- **Critical**: Errores críticos
- **None**: Deshabilitar logs

### Ejemplo de logging en el código

```csharp
using Microsoft.Extensions.Logging;

public class StudentsIndexModel : PageModel
{
    private readonly ILogger<StudentsIndexModel> _logger;

    public StudentsIndexModel(ILogger<StudentsIndexModel> logger)
    {
        _logger = logger;
    }

    public void OnGet()
    {
        _logger.LogInformation("Cargando lista de estudiantes");
        // ...
    }
}
```

### Ver logs en consola

Durante el desarrollo, los logs aparecen en la ventana **Output** de Visual Studio:
```
Salida > Mostrar salida de: Debug
```

---

## HTTPS

### Certificado autofirmado (Desarrollo)

Ya está configurado por defecto. Si necesitas regenerarlo:

```bash
dotnet dev-certs https --clean
dotnet dev-certs https --trust
```

### Forzar HTTPS

En `Program.cs` ya está habilitado:

```csharp
app.UseHttpsRedirection();
```

### HSTS (HTTP Strict Transport Security)

```csharp
if (!app.Environment.IsDevelopment())
{
    app.UseHsts(); // 30 días por defecto
}
```

Para cambiar el período:

```csharp
app.UseHsts(hsts => hsts.MaxAge(TimeSpan.FromDays(365)));
```

---

## Ejemplo: Configuración completa de producción

### `appsettings.Production.json`

```json
{
  "ConnectionStrings": {
    "UniversityContext": "Server=sql.example.com;Database=UniversityRazorDB;User Id=prod_user;Password=SuperSecurePassword123!;Encrypt=true;TrustServerCertificate=false;"
  },
  "Logging": {
    "LogLevel": {
      "Default": "Warning",
      "Microsoft.AspNetCore": "Error"
    }
  },
  "AllowedHosts": "www.example.com,example.com",
  "Cors": {
    "AllowedOrigins": [
      "https://www.example.com",
      "https://example.com"
    ]
  }
}
```

### `Program.cs` actualizado

```csharp
using Microsoft.EntityFrameworkCore;
using ProyectoRazor.Data;

var builder = WebApplication.CreateBuilder(args);

// Agregar servicios
builder.Services.AddRazorPages();
builder.Services.AddDbContext<UniversityContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("UniversityContext"),
        sqlServerOptionsAction: sqlOptions =>
        {
            sqlOptions.EnableRetryOnFailure(
                maxRetryCount: 5,
                maxRetryDelaySeconds: 30,
                errorNumbersToAdd: null);
        }));

var app = builder.Build();

// Configurar HTTP pipeline
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

app.MapRazorPages();

app.Run();
```

---

## ?? Desplegar en Azure

### 1. Crear recurso SQL Database en Azure

```bash
az sql server create --resource-group myResourceGroup --name myServer --location eastus
az sql db create --resource-group myResourceGroup --server myServer --name UniversityRazorDB
```

### 2. Actualizar cadena de conexión

```json
{
  "ConnectionStrings": {
    "UniversityContext": "Server=tcp:myServer.database.windows.net,1433;Initial Catalog=UniversityRazorDB;Persist Security Info=False;User ID=sqladmin;Password=MyPassword123!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;"
  }
}
```

### 3. Desplegar aplicación

```bash
dotnet publish -c Release
```

---

## ?? Referencias

- [Configuration in ASP.NET Core](https://docs.microsoft.com/en-us/aspnet/core/fundamentals/configuration/)
- [Entity Framework Core Connection Strings](https://docs.microsoft.com/en-us/ef/core/miscellaneous/connection-strings)
- [Logging in .NET Core](https://docs.microsoft.com/en-us/dotnet/core/extensions/logging)

---

¡Ahora tienes control total sobre la configuración de tu aplicación! ??
