# ? Preguntas Frecuentes (FAQ)

## Instalación y Requisitos

### P: ¿Necesito tener SQL Server instalado?
**R:** No. El proyecto usa **SQL Server LocalDB**, que se instala automáticamente con Visual Studio Community 2022.

### P: ¿Puedo usar SQL Server Express en lugar de LocalDB?
**R:** Sí. Modifica la cadena de conexión en `appsettings.json`:
```json
"Server=localhost;Database=UniversityRazorDB;Trusted_Connection=True;"
```

### P: ¿Funciona en Visual Studio Code?
**R:** Sí, pero necesitarás ejecutar los comandos desde la terminal:
```bash
dotnet add package Microsoft.EntityFrameworkCore.SqlServer
dotnet ef migrations add InitialCreate
dotnet ef database update
dotnet run
```

### P: ¿Necesito Git instalado?
**R:** No es obligatorio. Puedes descargar el ZIP directamente desde GitHub.

---

## Migraciones y Base de Datos

### P: ¿Qué significa "Add-Migration InitialCreate"?
**R:** Crea un archivo que describe los cambios en la base de datos. Es como un "screenshot" de tu modelo de datos.

### P: ¿Qué significa "Update-Database"?
**R:** Aplica los cambios del archivo de migración a la base de datos real.

### P: ¿Puedo borrar la base de datos?
**R:** Sí. Abre **SQL Server Object Explorer** en Visual Studio:
```
Vista > Explorador de objetos de SQL Server
```
Busca `UniversityRazorDB`, haz clic derecho > **Eliminar**.

Luego ejecuta nuevamente:
```powershell
Update-Database
```

### P: ¿Qué pasa si ejecuto "Update-Database" dos veces?
**R:** No pasa nada. Entity Framework verifica qué migraciones ya se aplicaron.

### P: ¿Dónde está el archivo de la base de datos?
**R:** LocalDB lo guarda en:
```
C:\Users\[TuUsuario]\AppData\Local\Microsoft\Microsoft SQL Server Local DB\Instances\mssqllocaldb\
```

---

## Ejecución y Errores

### P: ¿Por qué dice "ERR_CONNECTION_REFUSED"?
**R:** La aplicación no está ejecutándose. Presiona **F5** nuevamente.

### P: ¿Por qué dice "Build failed"?
**R:** 
1. Presiona **Mayús + Alt + F5** para detener
2. Ve a **Compilar > Limpiar solución**
3. Presiona **F5** nuevamente

### P: ¿Cómo sé qué puerto está usando?
**R:** Mira la **ventana Salida** de Visual Studio cuando ejecutes (F5). Busca:
```
Now listening on: https://localhost:7XXX
```

### P: ¿Puedo cambiar el puerto?
**R:** Sí. Abre `Properties/launchSettings.json` y modifica:
```json
"applicationUrl": "https://localhost:7123;http://localhost:5123"
```

---

## Funcionalidad

### P: ¿Puedo eliminar todos los estudiantes?
**R:** Sí, pero si tienes inscripciones relacionadas, se eliminarán automáticamente (cascada).

### P: ¿Puedo editar un estudiante después de inscribirlo?
**R:** Sí. Los cambios se actualizarán en todas sus inscripciones.

### P: ¿Dónde se guardan los datos?
**R:** En la base de datos SQL Server LocalDB. No se borran si cierras Visual Studio.

### P: ¿Cómo borro todos los datos sin eliminar la BD?
**R:** En la **Consola del Administrador de Paquetes**, ejecuta:
```powershell
Remove-Migration
Add-Migration InitialCreate
Update-Database
```

---

## Desarrollo

### P: ¿Cómo agrego nuevos campos a un modelo?
**R:** 
1. Edita la clase en `Models` (ej: `Student.cs`)
2. Ejecuta:
   ```powershell
   Add-Migration AddNewField
   Update-Database
   ```

### P: ¿Cómo cambio el diseño de las páginas?
**R:** Edita los archivos `.cshtml` en `Pages/`. Usa Bootstrap 5 para los estilos.

### P: ¿Cómo agrego validaciones?
**R:** En los modelos, usa atributos:
```csharp
[Required(ErrorMessage = "El nombre es obligatorio")]
[StringLength(100)]
public string FirstName { get; set; }
```

### P: ¿Cómo veo los cambios sin reiniciar?
**R:** En algunas ocasiones, Visual Studio recompila automáticamente. Si no, presiona **Ctrl + Mayús + B**.

---

## Git y Repositorio

### P: ¿Cómo subo mis cambios al repositorio?
**R:**
```bash
git add .
git commit -m "Descripción de cambios"
git push origin develop
```

### P: ¿Qué significa "merge conflict"?
**R:** Cuando dos personas editan el mismo archivo. Visual Studio te ayuda a resolver. Consulta la documentación de Git.

### P: ¿Puedo hacer "pull" si tengo cambios locales?
**R:** No. Primero haz `commit` o `stash`:
```bash
git stash
git pull origin develop
```

---

## Performance y Optimización

### P: ¿Qué pasa si tengo 10,000 estudiantes?
**R:** La página se cargará más lentamente. Para optimizar:
- Agrega paginación
- Usa búsqueda/filtros
- Crea índices en la BD

### P: ¿Cómo hago que sea más rápido?
**R:** Lee sobre:
- [Entity Framework Query Performance](https://docs.microsoft.com/en-us/ef/core/querying/related-data/)
- [SQL Server Indexing](https://docs.microsoft.com/en-us/sql/relational-databases/indexes/indexes)

---

## Seguridad

### P: ¿Es seguro tener "Trusted_Connection=True" en la cadena de conexión?
**R:** Para desarrollo local, sí. Para producción, usa autenticación y encriptación.

### P: ¿Hay autenticación integrada?
**R:** No. El proyecto actual es públicamente accesible. Para agregar login, usa **ASP.NET Core Identity**.

### P: ¿Cómo protejo los datos?
**R:** Agrega:
- [ASP.NET Core Identity](https://docs.microsoft.com/en-us/aspnet/core/security/authentication/)
- [Authorization Policies](https://docs.microsoft.com/en-us/aspnet/core/security/authorization/)
- HTTPS (ya configurado)

---

## Próximas preguntas

Si tu pregunta no está aquí, abre un **Issue** en GitHub:
```
https://github.com/rhq-omni777/ProyectoRazor/issues
```

---

**¡Espero que esto ayude!** ??
