# ?? Guía Completa: Clonar y Ejecutar ProyectoRazor

Esta guía te llevará paso a paso para clonar el repositorio y ejecutar la aplicación de gestión universitaria.

## ?? Índice

1. [Requisitos previos](#-requisitos-previos)
2. [Clonar el repositorio](#-clonar-el-repositorio)
3. [Abrir el proyecto en Visual Studio](#-abrir-el-proyecto-en-visual-studio)
4. [Configurar la base de datos](#-configurar-la-base-de-datos)
5. [Ejecutar la aplicación](#-ejecutar-la-aplicación)
6. [Solución de problemas](#-solución-de-problemas)
7. [Próximos pasos](#-próximos-pasos)

---

## ? Requisitos previos

Antes de empezar, asegúrate de tener instalado:

- **Visual Studio Community 2022** (o superior)
  - [Descargar aquí](https://visualstudio.microsoft.com/es/vs/community/)
  - Durante la instalación, marca la carga de trabajo: **"Desarrollo de ASP.NET y web"**

- **.NET 10.0 SDK**
  - Se instala automáticamente con Visual Studio 2022

- **SQL Server LocalDB**
  - Se incluye en Visual Studio Community 2022
  - Si no lo tienes, lo puedes instalar desde SQL Server Express

- **Git** (opcional pero recomendado)
  - [Descargar aquí](https://git-scm.com/)

---

## ?? Clonar el repositorio

### Opción 1: Usar Git en la terminal (Recomendado)

1. Abre **PowerShell** o **Command Prompt**

2. Ve a la carpeta donde quieras guardar el proyecto:
   ```bash
   cd C:\Mis Proyectos
   ```

3. Clona el repositorio:
   ```bash
   git clone https://github.com/rhq-omni777/ProyectoRazor.git
   ```

4. Entra en la carpeta del proyecto:
   ```bash
   cd ProyectoRazor
   ```

### Opción 2: Descargar directamente desde GitHub

1. Ve a: https://github.com/rhq-omni777/ProyectoRazor
2. Haz clic en el botón verde **Code**
3. Selecciona **Download ZIP**
4. Extrae la carpeta en tu disco

---

## ?? Abrir el proyecto en Visual Studio

1. **Abre Visual Studio Community 2022**

2. Selecciona **"Abrir un proyecto o una solución"**

3. Navega a la carpeta del proyecto y abre:
   ```
   ProyectoRazor\ProyectoRazor.sln
   ```

4. **Espera a que se cargue completamente** (verás un progreso en la parte inferior)

5. En el **Explorador de soluciones** (derecha), verifica que veas:
   - `ProyectoRazor` (carpeta raíz del proyecto)
   - `Models` (Student, Course, Enrollment)
   - `Data` (UniversityContext)
   - `Pages` (Estudiantes, Cursos, Inscripciones)

---

## ??? Configurar la base de datos

### Paso 1: Verificar la conexión a la base de datos

1. Abre el archivo `appsettings.json` (en la raíz del proyecto)

2. Verifica que la cadena de conexión sea:
   ```json
   "ConnectionStrings": {
       "UniversityContext": "Server=(localdb)\\mssqllocaldb;Database=UniversityRazorDB;Trusted_Connection=True;MultipleActiveResultSets=true"
   }
   ```

Si es diferente, reemplázala con la de arriba.

### Paso 2: Crear las migraciones

1. En Visual Studio, ve a:
   ```
   Herramientas > Administrador de paquetes NuGet > Consola del Administrador de paquetes
   ```

2. Se abrirá una consola en la parte inferior. Asegúrate de que el **Proyecto predeterminado** es `ProyectoRazor`

3. Ejecuta este comando:
   ```powershell
   Add-Migration InitialCreate
   ```

   Verás algo como:
   ```
   Build started...
   Build succeeded.
   To undo this action, use 'Remove-Migration'.
   ```

### Paso 3: Aplicar las migraciones a la base de datos

1. En la misma consola, ejecuta:
   ```powershell
   Update-Database
   ```

2. Espera a que termine. Verás:
   ```
   Applying migration '20251216043310_InitialCreate'.
   Done.
   ```

   **¡Excelente! La base de datos ya está creada.**

---

## ?? Ejecutar la aplicación

### Opción 1: Usar el botón Play (Más fácil)

1. En Visual Studio, busca el botón **Play** verde (?) en la parte superior

2. Haz clic en él

### Opción 2: Usar el teclado

Presiona **F5**

### ¿Qué sucede?

- Visual Studio compilará la aplicación
- Se abrirá automáticamente tu navegador predeterminado
- Verás la página de inicio con 3 tarjetas: **Estudiantes**, **Cursos**, **Inscripciones**

---

## ?? Probar la aplicación

Una vez abierta, prueba estas funciones:

### 1. Crear un estudiante

1. Haz clic en **"Estudiantes"** en la barra de navegación (o en la tarjeta)

2. Haz clic en **"Agregar Nuevo Estudiante"**

3. Completa el formulario:
   - **Nombre**: Juan
   - **Apellido**: Pérez
   - **Fecha de Inscripción**: 2025-01-15

4. Haz clic en **"Guardar"**

5. Verifica que aparezca en la lista

### 2. Crear un curso

1. Haz clic en **"Cursos"** en la barra de navegación

2. Haz clic en **"Agregar Nuevo Curso"**

3. Completa el formulario:
   - **Título**: Programación en C#
   - **Créditos**: 4

4. Haz clic en **"Guardar"**

### 3. Crear una inscripción

1. Haz clic en **"Inscripciones"** en la barra de navegación

2. Haz clic en **"Agregar Nueva Inscripción"**

3. Completa el formulario:
   - **Estudiante**: Selecciona "Juan Pérez"
   - **Curso**: Selecciona "Programación en C#"
   - **Calificación**: A

4. Haz clic en **"Guardar"**

### 4. Probar Editar y Eliminar

En cualquier listado (Estudiantes, Cursos, Inscripciones), verás botones:
- **Editar**: Modifica los datos
- **Eliminar**: Elimina el registro (te pedirá confirmación)

---

## ?? Solución de problemas

### Problema: "ERR_CONNECTION_REFUSED" al abrir localhost

**Solución:**
1. Asegúrate de que Visual Studio está ejecutando la aplicación (busca el botón Play en rojo)
2. Presiona F5 nuevamente
3. Si persiste, cierra el navegador y vuelve a ejecutar (F5)

### Problema: "The database already exists" al ejecutar Update-Database

**Solución:**
```powershell
Remove-Migration
Add-Migration InitialCreate
Update-Database
```

### Problema: "Build failed" en Update-Database

**Solución:**
1. Presiona **Mayús + Alt + F5** para detener la depuración
2. Ve a **Compilar > Limpiar solución**
3. Espera a que termine
4. Intenta `Update-Database` nuevamente

### Problema: No aparecen las tablas en la base de datos

**Solución:**
1. Verifica que ejecutaste correctamente:
   ```powershell
   Update-Database
   ```
2. Abre el **Explorador de objetos de SQL Server** (Vista > Explorador de objetos de SQL Server)
3. Busca: `(localdb)\mssqllocaldb > Bases de datos > UniversityRazorDB`
4. Expande y verifica que ves las tablas: `Students`, `Courses`, `Enrollments`

### Problema: "The model backing the Context has changed"

**Solución:**
```powershell
Remove-Migration
Add-Migration InitialCreate
Update-Database
```

---

## ?? Estructura del proyecto

```
ProyectoRazor/
??? Models/
?   ??? Student.cs           # Entidad de Estudiante
?   ??? Course.cs            # Entidad de Curso
?   ??? Enrollment.cs        # Entidad de Inscripción
??? Data/
?   ??? UniversityContext.cs # Contexto de Entity Framework
??? Pages/
?   ??? Index.cshtml         # Página de inicio
?   ??? Students/            # CRUD de Estudiantes (4 páginas)
?   ??? Courses/             # CRUD de Cursos (4 páginas)
?   ??? Enrollments/         # CRUD de Inscripciones (4 páginas)
?   ??? Shared/
?       ??? _Layout.cshtml   # Diseño principal
??? Migrations/
?   ??? 20251216043310_InitialCreate.cs  # Migraciones de la BD
??? appsettings.json         # Configuración (conexión a BD)
??? Program.cs               # Configuración principal
??? README.md                # Documentación
```

---

## ?? Tecnologías utilizadas

- **Framework**: ASP.NET Core 10.0
- **Patrón**: Razor Pages
- **ORM**: Entity Framework Core
- **Base de datos**: SQL Server (LocalDB)
- **Frontend**: Bootstrap 5
- **Lenguaje**: C# 14.0

---

## ?? Cambios recientes

Para ver una lista completa de cambios realizados, abre:
```
ProyectoRazor/CAMBIOS.md
```

---

## ?? Próximos pasos

Después de que la aplicación esté funcionando, puedes:

### 1. Agregar validaciones adicionales
```csharp
[Required(ErrorMessage = "El nombre es requerido")]
public string FirstName { get; set; }
```

### 2. Agregar búsqueda y filtros
En las páginas `Index`, agrega parámetros de búsqueda

### 3. Agregar autenticación
Usa ASP.NET Core Identity para login de usuarios

### 4. Crear reportes
Exporta datos a PDF o Excel

### 5. Mejorar el diseño
Personaliza los estilos CSS en `wwwroot/css/site.css`

---

## ?? Tips útiles

- **Compilar sin ejecutar**: `Ctrl + Mayús + B`
- **Limpiar solución**: `Compilar > Limpiar solución`
- **Reconstruir solución**: `Compilar > Reconstruir solución`
- **Ver migraciones pendientes**: En la consola, escribe `Get-DbContext`

---

## ?? Soporte

Si tienes problemas:

1. **Verifica los logs** en la ventana "Salida" de Visual Studio
2. **Busca el error en Google** con el mensaje exacto
3. **Consulta la documentación oficial**:
   - [Entity Framework Core](https://docs.microsoft.com/en-us/ef/core/)
   - [ASP.NET Core Razor Pages](https://docs.microsoft.com/en-us/aspnet/core/razor-pages/)

---

## ? ¡Felicidades!

Si seguiste todos estos pasos, ahora tienes un **sistema de gestión universitario completamente funcional**. ??

### Características que tienes:

? Gestión de Estudiantes (Crear, Leer, Editar, Eliminar)
? Gestión de Cursos (Crear, Leer, Editar, Eliminar)
? Gestión de Inscripciones (Crear, Leer, Editar, Eliminar)
? Interfaz responsiva con Bootstrap 5
? Base de datos SQL Server con relaciones
? Validación de formularios
? Navegación intuitiva

---

**¿Necesitas ayuda? ¡Revisa la sección de Solución de problemas arriba!** ??
