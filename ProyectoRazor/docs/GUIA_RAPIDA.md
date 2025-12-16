# ? Guía Rápida (5 minutos)

Si ya tienes Visual Studio instalado, sigue estos pasos rápidos:

## 1?? Clonar el repositorio

```bash
git clone https://github.com/rhq-omni777/ProyectoRazor.git
cd ProyectoRazor
```

## 2?? Abrir en Visual Studio

```
Archivo > Abrir > ProyectoRazor/ProyectoRazor.sln
```

## 3?? Crear la base de datos

Abre la **Consola del Administrador de Paquetes**:
```
Herramientas > Administrador de paquetes NuGet > Consola del Administrador de paquetes
```

Ejecuta estos dos comandos:

```powershell
Add-Migration InitialCreate
Update-Database
```

## 4?? Ejecutar

Presiona **F5** o el botón **Play** verde.

---

## ? ¡Listo!

La aplicación se abrirá en `https://localhost:7xxx`

---

## ?? Prueba rápida

1. Ve a **Estudiantes** > **Agregar Nuevo Estudiante**
2. Ingresa: Nombre: Juan, Apellido: Pérez, Fecha: 2025-01-15
3. Guarda y verifica que aparezca en la lista

---

Para una guía más detallada, abre: `docs/GUIA_INSTALACION.md`
