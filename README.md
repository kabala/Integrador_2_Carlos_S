# Integrador 2 - CRUD Clientes

Aplicación web ASP.NET Core MVC (.NET 10) con CRUD completo para la tabla Clientes usando ADO.NET puro (sin ORM) conectado a SQL Server LocalDB.

## Requisitos

- Visual Studio 2022/2026
- .NET 10 SDK
- SQL Server LocalDB (incluido con Visual Studio)

## Configuración de la Base de Datos

### Opción 1: Ejecutar desde terminal (PowerShell)

```powershell
sqlcmd -S "(localdb)\MSSQLLocalDB" -E -i "Integrador_2_Carlos_S\DatabaseScript.sql"
```

### Opción 2: Desde Visual Studio

1. Abrir **Ver > Explorador de objetos de SQL Server**
2. Conectar a `(localdb)\MSSQLLocalDB`
3. Click derecho > **Nueva consulta**
4. Pegar el contenido de `DatabaseScript.sql`
5. Ejecutar (Ctrl+Shift+E)

### Opción 3: Desde SQL Server Management Studio (SSMS)

1. Conectar al servidor `(localdb)\MSSQLLocalDB`
2. Abrir `DatabaseScript.sql`
3. Ejecutar

## Cadena de Conexión

La cadena de conexión se encuentra en `appsettings.json`:

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=(localdb)\\MSSQLLocalDB;Database=ClientesDB;Trusted_Connection=True;TrustServerCertificate=True;"
}
```

Si usas una instancia diferente de SQL Server, modifica el valor de `Server`:

| Instancia | Valor |
|-----------|-------|
| LocalDB | `(localdb)\MSSQLLocalDB` |
| SQL Express | `.\SQLEXPRESS` |
| SQL Server local | `localhost` |

## Ejecutar la Aplicación

1. Abrir la solución en Visual Studio
2. Presionar F5 o Ctrl+F5
3. Navegar a `/Clientes`

## Estructura del Proyecto

```
├── Controllers/
│   └── ClientesController.cs    # Controlador CRUD
├── Data/
│   └── ClienteData.cs           # Acceso a datos con ADO.NET
├── Models/
│   └── Cliente.cs               # Modelo con 11 campos
├── Views/
│   └── Clientes/
│       ├── Index.cshtml          # Listado
│       ├── Create.cshtml         # Crear
│       ├── Edit.cshtml           # Editar
│       ├── Details.cshtml        # Detalles
│       └── Delete.cshtml         # Eliminar
├── DatabaseScript.sql            # Script de creación de BD
└── appsettings.json              # Cadena de conexión
```

## Campos de la tabla Clientes

| Campo | Tipo | Descripción |
|-------|------|-------------|
| Id | INT (PK, Identity) | Identificador único |
| Nombre | NVARCHAR(100) | Nombre del cliente |
| Apellido | NVARCHAR(100) | Apellido del cliente |
| Email | NVARCHAR(150) | Correo electrónico (único) |
| Telefono | NVARCHAR(20) | Número de teléfono |
| Direccion | NVARCHAR(200) | Dirección física |
| Ciudad | NVARCHAR(100) | Ciudad de residencia |
| CodigoPostal | NVARCHAR(10) | Código postal |
| FechaNacimiento | DATE | Fecha de nacimiento |
| Activo | BIT | Estado del cliente |
| FechaRegistro | DATETIME | Fecha de alta automática |

## Resetear la Base de Datos

Si necesitas eliminar y recrear la base de datos:

```powershell
sqlcmd -S "(localdb)\MSSQLLocalDB" -E -Q "DROP DATABASE ClientesDB"
sqlcmd -S "(localdb)\MSSQLLocalDB" -E -i "Integrador_2_Carlos_S\DatabaseScript.sql"
```
