# Proyecto Razor Pages - Universidad

Sistema de gestión de estudiantes, cursos e inscripciones desarrollado con ASP.NET Core Razor Pages y Entity Framework Core.

## ?? Requisitos

- Visual Studio Community 2022
- .NET 10.0
- SQL Server LocalDB (incluido en Visual Studio)

## ?? Cómo ejecutar el proyecto

### 1. Preparar la solución

1. Abre la solución en Visual Studio
2. En el Explorador de soluciones, asegúrate de que el proyecto `ProyectoRazor` está disponible

### 2. Instalar las dependencias de Entity Framework (si no están instaladas)

Abre la **Consola del Administrador de paquetes** en Visual Studio:
- Ve a **Herramientas > Administrador de paquetes NuGet > Consola del Administrador de paquetes**

Ejecuta los siguientes comandos (si no están instalados):

```powershell
Install-Package Microsoft.EntityFrameworkCore.SqlServer
Install-Package Microsoft.EntityFrameworkCore.Tools
```

### 3. Crear la base de datos (Migraciones)

En la **Consola del Administrador de paquetes**, ejecuta:

```powershell
Add-Migration InitialCreate
```

Luego:

```powershell
Update-Database
```

Esto creará la base de datos `UniversityRazorDB` en tu SQL Server LocalDB.

### 4. Ejecutar el proyecto

Presiona **F5** o haz clic en el botón **"Play"** verde en la parte superior de Visual Studio.

El navegador se abrirá automáticamente en `https://localhost:7xxx` (el puerto puede variar).

## ?? Características principales

### ?? Gestión de Estudiantes
- **Ver**: Lista de todos los estudiantes
- **Crear**: Agregar nuevo estudiante (Nombre, Apellido, Fecha de Inscripción)
- **Editar**: Modificar datos de un estudiante existente
- **Eliminar**: Eliminar un estudiante del sistema

**Acceso**: `/Students` o desde el menú principal

### ?? Gestión de Cursos
- **Ver**: Lista de todos los cursos
- **Crear**: Agregar nuevo curso (Título, Créditos)
- **Editar**: Modificar datos de un curso
- **Eliminar**: Eliminar un curso del sistema

**Acceso**: `/Courses` o desde el menú principal

### ?? Gestión de Inscripciones
- **Ver**: Lista de todas las inscripciones con detalles de estudiante y curso
- **Crear**: Inscriben un estudiante en un curso (asignar calificación)
- **Editar**: Modificar la calificación de una inscripción
- **Eliminar**: Eliminar una inscripción

**Acceso**: `/Enrollments` o desde el menú principal

## ??? Estructura del proyecto

```
ProyectoRazor/
??? Models/                 # Entidades de la aplicación
?   ??? Student.cs         # Modelo de Estudiante
?   ??? Course.cs          # Modelo de Curso
?   ??? Enrollment.cs      # Modelo de Inscripción
??? Data/
?   ??? UniversityContext.cs  # Contexto de Entity Framework
??? Pages/                  # Páginas Razor
?   ??? Index.cshtml        # Página de inicio
?   ??? Students/           # CRUD de Estudiantes
?   ??? Courses/            # CRUD de Cursos
?   ??? Enrollments/        # CRUD de Inscripciones
?   ??? Shared/             # Diseño compartido (_Layout.cshtml)
??? appsettings.json        # Configuración (incluyendo cadena de conexión)
??? Program.cs              # Configuración principal de la aplicación
```

## ?? Base de datos

La base de datos se crea automáticamente en SQL Server LocalDB con las siguientes tablas:

- **Students**: Almacena información de estudiantes
- **Courses**: Almacena información de cursos
- **Enrollments**: Almacena las inscripciones (relación entre estudiantes y cursos)

## ?? Relaciones entre tablas

```
Student (1) ???????? (N) Enrollment ???????? (N) Course
```

- Un estudiante puede tener muchas inscripciones
- Un curso puede tener muchas inscripciones
- Una inscripción pertenece a un estudiante y a un curso

## ??? Tecnologías utilizadas

- **Framework**: ASP.NET Core 10.0 (Razor Pages)
- **ORM**: Entity Framework Core
- **Base de datos**: SQL Server LocalDB
- **Frontend**: Bootstrap 5
- **Lenguaje**: C# 14.0

## ?? Notas importantes

1. **Conexión a la base de datos**: La cadena de conexión está configurada en `appsettings.json`:
   ```json
   "ConnectionStrings": {
       "UniversityContext": "Server=(localdb)\\mssqllocaldb;Database=UniversityRazorDB;Trusted_Connection=True;MultipleActiveResultSets=true"
   }
   ```

2. **Validaciones**: Los formularios incluyen validación del lado del cliente y servidor.

3. **Diseño responsivo**: La interfaz usa Bootstrap 5, lo que la hace responsiva en dispositivos móviles.

## ?? Solución de problemas

### Si la base de datos no se crea:
1. Asegúrate de que SQL Server LocalDB está en ejecución
2. Verifica que has ejecutado `Update-Database` en la consola del administrador de paquetes
3. Comprueba los mensajes de error en la consola de salida

### Si los datos no se guardan:
1. Verifica que no hay errores de validación en los formularios
2. Comprueba la conexión a la base de datos en `appsettings.json`
3. Revisa los logs en el Output window de Visual Studio

## ????? Próximas mejoras posibles

- Agregar autenticación y autorización
- Implementar reportes y estadísticas
- Agregar búsqueda y filtros avanzados
- Incluir validaciones más complejas
- Agregar páginas de errores personalizadas

## ?? Licencia

Este proyecto es de uso educativo.

---

**¡Espera que disfrutes trabajando con el proyecto!** ??
