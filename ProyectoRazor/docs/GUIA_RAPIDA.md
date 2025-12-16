# ?? Guía Rápida (5 minutos)

Si ya tienes Visual Studio instalado, sigue estos pasos rápidos para ejecutar el proyecto:

---

## ? Requisitos Previos

Antes de empezar, asegúrate de tener:

- **Visual Studio Community 2022** (o superior)
- **.NET 10.0 SDK** (se instala automáticamente con Visual Studio)
- **SQL Server LocalDB** (incluido en Visual Studio)
- **Git** (opcional pero recomendado)

---

## 1?? Clonar el repositorio

Abre PowerShell o Command Prompt y ejecuta:

```bash
git clone https://github.com/rhq-omni777/ProyectoRazor.git
cd ProyectoRazor
```

---

## 2?? Abrir en Visual Studio

1. Abre **Visual Studio Community 2022**
2. Selecciona **"Abrir un proyecto o una solución"**
3. Navega a la carpeta clonada y abre:
   ```
   ProyectoRazor\ProyectoRazor.sln
   ```
4. Espera a que el proyecto se cargue completamente

---

## 3?? Crear la base de datos

### Método 1: Consola del Administrador de Paquetes (Recomendado)

1. En Visual Studio, ve a:
   ```
   Herramientas > Administrador de paquetes NuGet > Consola del Administrador de paquetes
   ```

2. Asegúrate de que el **Proyecto predeterminado** es `ProyectoRazor`

3. Ejecuta estos comandos **en orden**:

   ```powershell
   Add-Migration InitialCreate
   Update-Database
   ```

4. Verás un mensaje: `Done.` - **¡Listo!**

### Método 2: Línea de comandos (.NET CLI)

Abre PowerShell en la carpeta del proyecto y ejecuta:

```powershell
dotnet ef migrations add InitialCreate
dotnet ef database update
```

---

## 4?? Ejecutar la aplicación

### Opción A: Botón Play
1. Busca el botón **Play** verde (??) en la parte superior de Visual Studio
2. Haz clic en él

### Opción B: Teclado
Presiona **F5**

---

## ? ¡Listo!

La aplicación se abrirá en `https://localhost:7xxx`

Verás la página de inicio con 3 tarjetas: **Estudiantes**, **Cursos**, **Inscripciones**

---

## ?? Prueba Rápida

### Crear un estudiante de prueba:

1. Haz clic en **"Estudiantes"** en la barra de navegación
2. Haz clic en **"Agregar Nuevo Estudiante"**
3. Ingresa los datos:
   - **Nombre**: Juan
   - **Apellido**: Pérez
   - **Fecha de Inscripción**: 2025-01-15
4. Haz clic en **"Guardar"**
5. ? Verifica que el estudiante aparezca en la lista

---

## ?? Verificar que los datos se guardan

Abre **SQL Server Object Explorer** en Visual Studio:
- Ve a: `View > SQL Server Object Explorer`
- Expande: `(localdb)\mssqllocaldb > Databases > UniversityRazorDB > Tables`
- Verás las tablas: `Students`, `Courses`, `Enrollments`

---

## ?? Problemas Comunes

### ? Error: "Add-Migration: not found"
**Solución**: Asegúrate de que tienes instalado Entity Framework Tools:
```powershell
dotnet tool install --global dotnet-ef
```

### ? Error: "The database already exists"
**Solución**: Si tienes una base de datos vieja, elimínala:
```powershell
Update-Database -TargetMigration 0
```

### ? Error: "Build failed"
**Solución**: 
1. Presiona **Ctrl + Shift + B** para compilar
2. Si persiste, limpia la solución: `Build > Clean Solution`
3. Reconstruye: `Build > Rebuild Solution`

### ? Error: "ERR_CONNECTION_REFUSED"
**Solución**: La aplicación no está corriendo. Presiona **F5** nuevamente.

---

## ?? Para una guía más detallada

Abre: `docs/GUIA_INSTALACION.md`

Ahí encontrarás:
- Solución de problemas más completa
- Estructura del proyecto
- Tecnologías utilizadas
- Próximos pasos para mejorar la aplicación

---

## ?? Características principales

? **Gestión de Estudiantes** - Crear, Editar, Eliminar, Listar  
? **Gestión de Cursos** - Crear, Editar, Eliminar, Listar  
? **Gestión de Inscripciones** - Crear, Editar, Eliminar, Listar  
? **Validación de formularios** - Campos requeridos y límites  
? **Base de datos SQL Server** - Con relaciones e integridad referencial  
? **Interfaz responsiva** - Con Bootstrap 5  

---

## ?? Tips útiles

- **Compilar sin ejecutar**: `Ctrl + Shift + B`
- **Detener la ejecución**: `Shift + Alt + F5`
- **Ver la consola de depuración**: `Debug > Windows > Output`
- **Buscar archivo**: `Ctrl + Shift + T`

---

## ?? ¿Listo para más?

Una vez que todo funcione, puedes:
- Agregar nuevos campos a los modelos
- Crear nuevas páginas CRUD
- Implementar filtros y búsqueda
- Agregar autenticación de usuarios

---

**¿Necesitas ayuda?** ?? Abre `docs/FAQ.md`
