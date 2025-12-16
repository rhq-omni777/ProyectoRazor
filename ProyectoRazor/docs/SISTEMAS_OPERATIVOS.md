# ??? Guía por Sistema Operativo

Selecciona tu sistema operativo para obtener instrucciones específicas.

---

## ?? Windows (Recomendado)

### Requisitos
- Windows 10 o superior
- Visual Studio Community 2022
- .NET 10.0 SDK

### Instalación

#### 1. Clonar el repositorio

**Opción A: Con Git**
```powershell
git clone https://github.com/rhq-omni777/ProyectoRazor.git
cd ProyectoRazor
```

**Opción B: Sin Git**
- Descarga el ZIP desde: https://github.com/rhq-omni777/ProyectoRazor
- Extrae la carpeta

#### 2. Abrir en Visual Studio
```
Archivo > Abrir > C:\[Tu carpeta]\ProyectoRazor\ProyectoRazor.sln
```

#### 3. Crear la base de datos
En Visual Studio, abre:
```
Herramientas > Administrador de paquetes NuGet > Consola del Administrador de paquetes
```

Ejecuta:
```powershell
Add-Migration InitialCreate
Update-Database
```

#### 4. Ejecutar
Presiona **F5** o haz clic en el botón **Play** verde.

### Solucionar problemas en Windows

**Problema: "Build failed"**
```powershell
# En la Consola del Administrador de Paquetes:
Remove-Module posh-git -ErrorAction Ignore
Update-Module posh-git
```

**Problema: "Access denied" en LocalDB**
```powershell
# En PowerShell (como administrador):
sqllocaldb stop mssqllocaldb
sqllocaldb start mssqllocaldb
```

---

## ?? macOS

### Requisitos
- macOS 10.15 o superior
- Visual Studio Code (recomendado)
- .NET 10.0 SDK
- Docker (para SQL Server)

### Instalación

#### 1. Instalar .NET SDK
```bash
# Descargar desde: https://dotnet.microsoft.com/en-us/download/dotnet/10.0
# O usar Homebrew:
brew install dotnet
```

#### 2. Clonar el repositorio
```bash
git clone https://github.com/rhq-omni777/ProyectoRazor.git
cd ProyectoRazor
```

#### 3. Instalar Docker (para SQL Server)
```bash
# Descargar Docker Desktop para Mac desde: https://www.docker.com/products/docker-desktop
brew install docker
```

#### 4. Crear contenedor de SQL Server
```bash
docker pull mcr.microsoft.com/mssql/server:2022-latest

docker run -e 'ACCEPT_EULA=Y' \
  -e 'SA_PASSWORD=YourPassword123!' \
  -p 1433:1433 \
  --name mssql-server \
  -d mcr.microsoft.com/mssql/server:2022-latest
```

#### 5. Actualizar cadena de conexión
Abre `appsettings.json` y reemplaza:
```json
{
  "ConnectionStrings": {
    "UniversityContext": "Server=localhost,1433;Database=UniversityRazorDB;User Id=sa;Password=YourPassword123!;MultipleActiveResultSets=true;"
  }
}
```

#### 6. Restaurar paquetes
```bash
dotnet restore
```

#### 7. Crear la base de datos
```bash
dotnet ef migrations add InitialCreate
dotnet ef database update
```

#### 8. Ejecutar
```bash
dotnet run
```

Abre en el navegador: `https://localhost:5001`

### Solucionar problemas en macOS

**Problema: "dotnet: command not found"**
```bash
# Agregar a ~/.zshrc o ~/.bash_profile:
export PATH="$PATH:/usr/local/share/dotnet"

# Recargar:
source ~/.zshrc
```

**Problema: SQL Server no se conecta**
```bash
# Verificar si Docker está ejecutándose:
docker ps

# Si no aparece, reiniciar:
docker start mssql-server
```

---

## ?? Linux (Ubuntu/Debian)

### Requisitos
- Ubuntu 20.04 o superior
- .NET 10.0 SDK
- SQL Server (en Docker)
- Visual Studio Code (opcional)

### Instalación

#### 1. Instalar .NET SDK
```bash
# Agregar repositorio Microsoft
wget https://packages.microsoft.com/config/ubuntu/20.04/packages-microsoft-prod.deb -O packages-microsoft-prod.deb
sudo dpkg -i packages-microsoft-prod.deb

# Instalar .NET
sudo apt-get update
sudo apt-get install -y dotnet-sdk-10.0
```

#### 2. Instalar Docker
```bash
curl -fsSL https://get.docker.com -o get-docker.sh
sudo sh get-docker.sh
sudo usermod -aG docker $USER
```

#### 3. Clonar el repositorio
```bash
git clone https://github.com/rhq-omni777/ProyectoRazor.git
cd ProyectoRazor
```

#### 4. Ejecutar SQL Server en Docker
```bash
docker pull mcr.microsoft.com/mssql/server:2022-latest

docker run -e 'ACCEPT_EULA=Y' \
  -e 'SA_PASSWORD=YourPassword123!' \
  -p 1433:1433 \
  --name mssql-server \
  -d mcr.microsoft.com/mssql/server:2022-latest
```

#### 5. Actualizar cadena de conexión
```bash
# Editar appsettings.json
nano appsettings.json
```

Reemplaza:
```json
{
  "ConnectionStrings": {
    "UniversityContext": "Server=localhost,1433;Database=UniversityRazorDB;User Id=sa;Password=YourPassword123!;MultipleActiveResultSets=true;"
  }
}
```

#### 6. Instalar herramientas de EF
```bash
dotnet tool install --global dotnet-ef
```

#### 7. Crear la base de datos
```bash
dotnet ef migrations add InitialCreate
dotnet ef database update
```

#### 8. Ejecutar
```bash
dotnet run
```

Abre en el navegador: `https://localhost:5001`

### Solucionar problemas en Linux

**Problema: "dotnet: command not found"**
```bash
export PATH="$PATH:/usr/share/dotnet"
```

**Problema: No tienes permisos de Docker**
```bash
sudo usermod -aG docker $USER
# Reinicia tu sesión o ejecuta:
newgrp docker
```

---

## ?? Usando Visual Studio Code (Todas las plataformas)

### Requisitos
- Visual Studio Code
- Extensión "C# Dev Kit"
- .NET 10.0 SDK

### Pasos

#### 1. Instalar extensión C# Dev Kit
En VS Code:
```
Extensiones > Busca "C# Dev Kit" > Instalar
```

#### 2. Clonar repositorio
```bash
git clone https://github.com/rhq-omni777/ProyectoRazor.git
code ProyectoRazor
```

#### 3. Abrir carpeta
```
Archivo > Abrir carpeta > ProyectoRazor
```

#### 4. Restaurar paquetes
```bash
dotnet restore
```

#### 5. Crear base de datos
En la terminal de VS Code:
```bash
dotnet ef migrations add InitialCreate
dotnet ef database update
```

#### 6. Ejecutar
```bash
dotnet run
```

O presiona **F5** con la extensión C# Dev Kit instalada.

---

## ?? Usando Docker Compose (Todas las plataformas)

### Crear archivo `docker-compose.yml`

```yaml
version: '3.8'

services:
  mssql:
    image: mcr.microsoft.com/mssql/server:2022-latest
    environment:
      SA_PASSWORD: "YourPassword123!"
      ACCEPT_EULA: "Y"
    ports:
      - "1433:1433"
    volumes:
      - mssql_data:/var/opt/mssql

  proyectorazor:
    build: .
    ports:
      - "5000:8080"
      - "5001:8443"
    environment:
      ConnectionStrings__UniversityContext: "Server=mssql,1433;Database=UniversityRazorDB;User Id=sa;Password=YourPassword123!;MultipleActiveResultSets=true;"
    depends_on:
      - mssql

volumes:
  mssql_data:
```

### Crear archivo `Dockerfile`

```dockerfile
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src
COPY ["ProyectoRazor/ProyectoRazor.csproj", "ProyectoRazor/"]
RUN dotnet restore "ProyectoRazor/ProyectoRazor.csproj"
COPY . .
RUN dotnet build "ProyectoRazor/ProyectoRazor.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ProyectoRazor/ProyectoRazor.csproj" -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:10.0
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ProyectoRazor.dll"]
```

### Ejecutar
```bash
docker-compose up --build
```

Accede a: `https://localhost:5001`

---

## ?? Comparativa de métodos

| Método | Windows | macOS | Linux | Dificultad |
|--------|---------|-------|-------|-----------|
| Visual Studio | ? Nativo | ? No disponible | ? No disponible | Fácil |
| VS Code | ? Sí | ? Sí | ? Sí | Medio |
| Línea de comandos | ? Sí | ? Sí | ? Sí | Difícil |
| Docker Compose | ? Sí | ? Sí | ? Sí | Medio |

---

## ?? Soporte multiplataforma

Si tienes problemas específicos de tu SO:

1. Consulta **FAQ.md** primero
2. Busca el error exacto en Google
3. Abre un Issue en GitHub con:
   - Tu SO y versión
   - Versión de .NET
   - Mensaje de error exacto

---

¡Elige tu plataforma y comienza! ??
